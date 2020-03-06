using Core.Entities;
using Core.Response;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Core.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly ApiResourceService _api;

        private const string GroupedByColumnQueryFormat = "SELECT SUM(TO_NUMBER(REPLACE(valor_pago, ',', '.'), '99999999999.99')::decimal(17,2)) as value, {0} as name from \"d4d8a7f0-d4be-4397-b950-f0c991438111\" GROUP BY {0} ORDER BY {0}";

        private const string MonthColumnName = "mes_movimentacao";
        private const string CategoryColumnName = "categoria_economica_nome";
        private const string SourceColumnName = "fonte_recurso_nome";

        public ExpenseService() : this(new ApiResourceService()) { }

        public ExpenseService(ApiResourceService api)
        {
            _api = api;
        }

        public async Task<IEnumerable<Expense>> GetAll()
        {
            var response = await _api.GetAsync<ExpenseSearchResponseData>();
            return response.Result.Records.Select(item =>
                new Expense(item.Id, item.Month, item.Year, item.CategoryId,
                item.CategoryName, item.SourceId, item.SourceName, item.Value));
        }

        public async Task<IEnumerable<ExpenseGroupedData>> GetGroupedDataByColumn(string columnName)
        {
            throw new NotImplementedException();
            //string sqlQuery = string.Format(GroupedByColumnQueryFormat, columnName);
            //var response = await _api.GetAsync<ExpenseSearchResponseData>(sqlQuery);
            //return response.Result.Records.Select(item => new ExpenseGroupedData(item.Name, item.Value));
        }

        public async Task<IEnumerable<ExpenseGroupedData>> GetGroupedByMonth()
        {
            var expenses = await GetAll();
            return expenses.GroupBy(e => e.Month)
                .Select(group => new ExpenseGroupedData(group.Key.ToString(), group.Sum(x => x.Value)))
                .OrderBy(x => x.Name);
        }

        public async Task<IEnumerable<ExpenseGroupedData>> GetGroupedByCategory()
        {
            var expenses = await GetAll();
            return expenses.GroupBy(e => e.CategoryName)
                .Select(group => new ExpenseGroupedData(group.Key.ToString(), group.Sum(x => x.Value)))
                .OrderBy(x => x.Name);
        }

        public async Task<IEnumerable<ExpenseGroupedData>> GetGroupedBySource()
        {
            var expenses = await GetAll();
            return expenses.GroupBy(e => e.SourceName)
                .Select(group => new ExpenseGroupedData(group.Key.ToString(), group.Sum(x => x.Value)))
                .OrderBy(x => x.Name);
        }

        public void Dispose()
        {
            _api.Dispose();
        }
    }
}
