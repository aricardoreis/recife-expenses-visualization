using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class ChartDataViewModel
    {
        public IEnumerable<BaseExpenseViewModel> Expenses { get; set; }
        public ChartType Type { get; set; }
        public string ColumnName { get; set; }
    }
}
