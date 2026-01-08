using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Claswork_ASP_APP.Pages
{
    public class TestModel : PageModel
    {
        public string Text { get; set; }

        public string WelcomeText { get; set; }

        private readonly IConfiguration _configuration;
        public TestModel(IConfiguration configuration)
        {
            _configuration = configuration;
            WelcomeText = _configuration["AplicationInfo:WelcomeText"];

            
        }
        public void OnGet()
        {
        }
    }
}
