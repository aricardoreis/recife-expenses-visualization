using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public interface IExpenseService
    {
        IList<Expense> GetAll();
        IList<ExpenseGroupedData> GetGroupedByMonth();
        IList<ExpenseGroupedData> GetGroupedByCategory();
        IList<ExpenseGroupedData> GetGroupedBySource();
    }
}
