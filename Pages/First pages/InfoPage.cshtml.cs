using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Claswork_ASP_APP.Pages
{
    public class InfoPageModel : PageModel
    {
        public IConfiguration _configuration;
        public string Title { get; set; }
        public string text { get; set; }
        public InfoPageModel(IConfiguration configuration)
        {
            _configuration = configuration;
            Title = _configuration["InfoText:Title"];
            text = _configuration["InfoText:Text"];
        }
        public void OnGet()
        {

        }
    }
}
