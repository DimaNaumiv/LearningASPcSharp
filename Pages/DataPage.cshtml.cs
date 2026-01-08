using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Claswork_ASP_APP.Pages
{
    public class DataPageModel : PageModel
    {
        public string Data { get; set; }
        public string Time { get; set; }

        public void OnGet()
        {
            Data = DateTime.Now.ToShortDateString();
            Time = DateTime.Now.ToShortTimeString();
        }
    }
}
