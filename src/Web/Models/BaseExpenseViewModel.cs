using System.ComponentModel;

namespace Web.Models
{
    public abstract class BaseExpenseViewModel
    {
        [DisplayName("Total")]
        public decimal Value { get; set; }
    }
}
