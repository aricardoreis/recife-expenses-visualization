using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Core.Services
{
    /// <summary>
    /// This class represents the service that makes the connection with the API.
    /// </summary>
    public class ApiResourceService : IDisposable
    {
        protected readonly HttpClient client = new HttpClient();
        private readonly string _endpoint;

        private readonly string _baseUri;

        public ApiResourceService()
        {
            _endpoint = "http://dados.recife.pe.gov.br/api/3/action/datastore_search_sql";

            _baseUri = $"{_endpoint}?sql=";

            client.BaseAddress = new Uri(_baseUri);
        }

        /// <summary>
        /// Makes a GET request for the API, processes the response (converting the data), and returns the data.
        /// </summary>
        /// <typeparam name="T">The target type.</typeparam>
        /// <param name="query">The SQL query.</param>
        /// <returns>The data that comes from the request.</returns>
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

        // Processes the response data serializing the JSON data to the target type.
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
