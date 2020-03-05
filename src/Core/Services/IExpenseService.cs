using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IExpenseService
    {
        Task<IEnumerable<Expense>> GetAll();
        Task<IEnumerable<ExpenseGroupedData>> GetGroupedByMonth();
        Task<IEnumerable<ExpenseGroupedData>> GetGroupedByCategory();
        Task<IEnumerable<ExpenseGroupedData>> GetGroupedBySource();
    }
}
