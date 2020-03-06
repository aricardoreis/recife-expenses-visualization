using System.ComponentModel;

namespace Web.Models
{
    public class CategorizedExpenseViewModel : BaseExpenseViewModel
    {
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
    }
}
