using System.ComponentModel;

namespace Web.Models
{
    public class SourceExpenseViewModel : BaseExpenseViewModel
    {
        [DisplayName("Source Name")]
        public string SourceName { get; set; }
    }
}
