using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class MonthlyExpenseViewModel
    {
        public string Month { get; set; }

        [DisplayName("Total")]
        public decimal Value { get; set; }

        [DisplayName("Month")]
        public string MonthName
        {
            get
            {
                CultureInfo en = new CultureInfo("en");
                return en.DateTimeFormat.GetMonthName(int.Parse(Month));
            }
        }
    }
}
