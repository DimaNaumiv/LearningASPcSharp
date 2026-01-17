using Claswork_ASP_APP.MyClasses;
using Claswork_ASP_APP.Serves;
using Copy_Classwork_APS_APP.DAL;
using Copy_Classwork_APS_APP.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace Claswork_ASP_APP.Pages
{
    public class ProfilePageModel : PageModel
    {
		public string Message { get; set; }
        public ProfileDTO Profile { get; set; }
		private IProfileServis _profileServis;

		public ProfilePageModel(IProfileServis profileServis)
		{
			_profileServis = profileServis;
		}
		public void OnGet()
        {
			Profile = _profileServis.GetLastProfile();
            if(Profile == null)
            {
				Message = "You are not registreted";
				return;
			}
        }
    }
}
