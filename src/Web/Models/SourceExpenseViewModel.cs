using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class SourceExpenseViewModel
    {
        [DisplayName("Source Name")]
        public string SourceName { get; set; }

        [DisplayName("Total")]
        public decimal Value { get; set; }
    }
}
