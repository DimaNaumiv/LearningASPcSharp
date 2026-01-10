using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Claswork_ASP_APP.MyClasses;

namespace Claswork_ASP_APP.Pages
{
    public class InputModelPageModel : PageModel
    {
		[BindProperty]
		public UserInputModel Input { get; set; }
        public string Name { get; set; }
        public void OnPostSave()
        {
            if (!ModelState.IsValid)
            {
                return;
			}
			Name = Input.Name;
		}
		public void OnPostDelete()
		{
			Input.Name = "";
		}

		public void OnGet()
        {
            Input = new UserInputModel();
            Input.Name = "User";
        }
    }
}
