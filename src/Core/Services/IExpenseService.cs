using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    /// <summary>
    /// This is the IExpenseService interface.
    /// It contains method signatures for the requests to the API.
    /// </summary>
    public interface IExpenseService : IDisposable
    {
        Task<IEnumerable<Expense>> GetAll();
        Task<IEnumerable<ExpenseGroupedData>> GetGroupedByMonth();
        Task<IEnumerable<ExpenseGroupedData>> GetGroupedByCategory();
        Task<IEnumerable<ExpenseGroupedData>> GetGroupedBySource();
    }
}
