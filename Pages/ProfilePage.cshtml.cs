using Claswork_ASP_APP.MyClasses;
using Copy_Classwork_APS_APP.DAL;
using Copy_Classwork_APS_APP.DAL.Interfaces;
using Copy_Classwork_APS_APP.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace Claswork_ASP_APP.Pages
{
    public class ProfilePageModel : PageModel
    {
		private ProfileInterface _profileInterface;
		public string Message { get; set; }
        public Profile Profile { get; set; }

		public ProfilePageModel(ProfileInterface profileInterface)
		{
			_profileInterface = profileInterface;
		}
		public void OnGet()
        {
            List<Profile> list = _profileInterface.GetAll();
			Profile = list.Last();
            if(Profile == null)
            {
				Message = "You are not registreted";
				return;
			}
        }
    }
}
