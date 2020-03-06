using System.ComponentModel;
using System.Globalization;

namespace Web.Models
{
    public class MonthlyExpenseViewModel : BaseExpenseViewModel
    {
        public string Month { get; set; }

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
