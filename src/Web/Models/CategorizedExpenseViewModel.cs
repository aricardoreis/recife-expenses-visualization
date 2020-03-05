using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class CategorizedExpenseViewModel
    {
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }

        [DisplayName("Total")]
        public decimal Value { get; set; }
    }
}
