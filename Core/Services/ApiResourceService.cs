using System;
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
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
