using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RequestPrototype.Pages
{
    public class StockDataDisplayModel : PageModel
    {
        public RequestPrototype.Models.Rootobject? JsonData { get; set; }
        public void OnGet()
        {
        }
    }
}
