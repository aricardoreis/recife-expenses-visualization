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

        private const string DataStoreSearchSqlUrl = "http://dados.recife.pe.gov.br/api/3/action/datastore_search";
        private const string DefaultResourceId = "d4d8a7f0-d4be-4397-b950-f0c991438111";

        private readonly string _endpoint;
        private readonly string _baseUri;

        public ApiResourceService()
        {
            _endpoint = DataStoreSearchSqlUrl;
            _baseUri = $"{_endpoint}?resource_id={DefaultResourceId}&limit=100000";

            client.BaseAddress = new Uri(_baseUri);
        }

        public async Task<T> GetAsync<T>()
        {
            HttpResponseMessage response = await client.GetAsync(_baseUri);
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
            return await Task.FromResult(JsonConvert.DeserializeObject<T>(data, new JsonSerializerSettings
            {
                Culture = new System.Globalization.CultureInfo("pt-BR")
            })).ConfigureAwait(false);
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
