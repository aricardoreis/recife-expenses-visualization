using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ApiResourceService : IDisposable
    {
        protected readonly HttpClient client = new HttpClient();
        private readonly string _endpoint;

        private string _baseUri;

        public ApiResourceService()
        {
            _endpoint = "http://dados.recife.pe.gov.br/api/3/action/datastore_search_sql";

            _baseUri = $"{_endpoint}?sql=";

            client.BaseAddress = new Uri(_baseUri);
        }

        public async Task<T> GetAsync<T>(string query)
        {
            string requestUri = $"{_baseUri}{query}";
            HttpResponseMessage response = await client.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                return await ProcessResponse<T>(response);
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        private async Task<T> ProcessResponse<T>(HttpResponseMessage response)
        {
            var data = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return await Task.FromResult(JsonConvert.DeserializeObject<T>(data)).ConfigureAwait(false);
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
