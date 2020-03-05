using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Expense
    {
        public int Id { get; private set; }
        public int Month { get; private set; }
        public int Year { get; private set; }
        public int CategoryId { get; private set; }
        public string CategoryName { get; private set; }
        public int SourceId { get; private set; }
        public string SourceName { get; private set; }
        public decimal Value { get; private set; }
    }

    public class ExpenseGroupedData
    {
        public ExpenseGroupedData(string name, decimal value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; private set; }
        public decimal Value { get; private set; }
    }
}
