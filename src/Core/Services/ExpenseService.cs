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

        private const string GroupedByColumnQueryFormat = "SELECT SUM(TO_NUMBER(REPLACE(valor_pago, ',', '.'), '99999999999.99')::decimal(17,2)) as value, {0} as name from \"d4d8a7f0-d4be-4397-b950-f0c991438111\" GROUP BY {0} ORDER BY {0}";
        private const string GroupedByAllQueryFormat = "SELECT SUM(TO_NUMBER(REPLACE(valor_pago, ',', '.'), '99999999999.99')::decimal(17,2)) as value, mes_movimentacao, fonte_recurso_nome, categoria_economica_nome from \"d4d8a7f0-d4be-4397-b950-f0c991438111\" GROUP BY mes_movimentacao, fonte_recurso_nome, categoria_economica_nome ORDER BY mes_movimentacao, fonte_recurso_nome, categoria_economica_nome";

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
            string sqlQuery = GroupedByAllQueryFormat;
            var response = await _api.GetAsync<ExpenseSearchResponseData>(sqlQuery);
            return response.Result.Records.Select(item => new Expense(item.Month, item.CategoryName, item.SourceName, item.Value));
        }

        public async Task<IEnumerable<ExpenseGroupedData>> GetGroupedDataByColumn(string columnName)
        {
            string sqlQuery = string.Format(GroupedByColumnQueryFormat, columnName);
            var response = await _api.GetAsync<ExpenseSearchResponseData>(sqlQuery);
            return response.Result.Records.Select(item => new ExpenseGroupedData(item.Name, item.Value));
        }

        public async Task<IEnumerable<ExpenseGroupedData>> GetGroupedByMonth()
        {
            return await GetGroupedDataByColumn(MonthColumnName);
        }

        public async Task<IEnumerable<ExpenseGroupedData>> GetGroupedByCategory()
        {
            return await GetGroupedDataByColumn(CategoryColumnName);
        }

        public async Task<IEnumerable<ExpenseGroupedData>> GetGroupedBySource()
        {
            return await GetGroupedDataByColumn(SourceColumnName);
        }

        public void Dispose()
        {
            _api.Dispose();
        }
    }
}
