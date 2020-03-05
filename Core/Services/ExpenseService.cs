using Core.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Core.Services
{
    public class ExpenseService : IExpenseService
    {
        public IList<Expense> GetAll()
        {
            throw new NotImplementedException();
        }

        public IList<ExpenseGroupedData> GetGroupedByCategory()
        {
            throw new NotImplementedException();
        }

        public IList<ExpenseGroupedData> GetGroupedByMonth()
        {
            throw new NotImplementedException();
        }

        public IList<ExpenseGroupedData> GetGroupedBySource()
        {
            throw new NotImplementedException();
        }
    }
}
