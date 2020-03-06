using System.ComponentModel;
using System.Globalization;

namespace Web.Models
{
    public abstract class BaseExpenseViewModel
    {
        [DisplayName("Total (BRL)")]
        public decimal Value { get; set; }

        public string FormattedValue
        {
            get
            {
                CultureInfo en = new CultureInfo("en-US");
                return Value.ToString("N", en);
            }
        }

    }
}
