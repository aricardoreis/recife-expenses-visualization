using Core.Entities;
using Core.Response;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly ApiResourceService _api;

        public ExpenseService() : this(new ApiResourceService()) { }

        public ExpenseService(ApiResourceService api)
        {
            _api = api;
        }

        public async Task<IEnumerable<Expense>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ExpenseGroupedData>> GetGroupedByMonth()
        {
            string sqlQuery = "SELECT SUM(TO_NUMBER(REPLACE(valor_pago, ',', '.'), '99999999999.99')::decimal(17,2)) as value, mes_movimentacao as name from \"d4d8a7f0-d4be-4397-b950-f0c991438111\" GROUP BY mes_movimentacao ORDER BY mes_movimentacao";
            var response = await _api.GetAsync<ExpenseSearchResponseData>(sqlQuery);
            return response.Result.Records.Select(item => new ExpenseGroupedData(item.Name, item.Value));
        }

        public async Task<IEnumerable<ExpenseGroupedData>> GetGroupedByCategory()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ExpenseGroupedData>> GetGroupedBySource()
        {
            throw new NotImplementedException();
        }

    }
}
