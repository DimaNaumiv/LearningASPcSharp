using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Claswork_ASP_APP.MyClasses;
using Copy_Classwork_APS_APP.DAL.Models;
using Copy_Classwork_APS_APP.DAL;
using Copy_Classwork_APS_APP.DAL.Interfaces;

namespace Claswork_ASP_APP.Pages
{
    public class RegisterPageModel : PageModel
    {
		private ProfileInterface _profileInterface;
		[BindProperty]
		public Profile Profile { get; set; }
		public string Succses { get; set; }
		public string Error { get; set; }

		private bool ErrorChecher()
		{
			if(Profile.FirstName == "" || Profile.FirstName==null)
			{
				Error = "First name is empty";
				return false;
			}
			else if (Profile.FirstName.Length<2)
			{
				Error = "First name is smoler then 2 simbols";
				return false;
			}

			if (Profile.LastName == "" || Profile.LastName == null)
			{
				Error = "Last name is empty";
				return false;
			}
			else if (Profile.LastName.Length < 2)
			{
				Error = "Last name is smoler then 2 simbols";
				return false;
			}

			if (Profile.Email == ""|| Profile.Email == null)
			{
				Error = "Email is empty";
				return false;
			}

			if (Profile.PhoneNumber == "" || Profile.PhoneNumber == null)
			{
				Error = "phone number is empty";
				return false;
			}

			if (Profile.Gender == "" || Profile.Gender == null)
			{
				Error = "gender is empty";
				return false;
			}

			Error = "";
			return true;
		}
		private string TextAdder(string text)
		{
			if(Profile.BirthDate==null || Profile.BirthDate == "")
			{
				text = text + "null ";
			}
			else
			{
				text = text + Profile.BirthDate+" ";
			}

			if(Profile.Country == null || Profile.Country == "")
			{
				text = text + "null ";
			}
			else
			{
				text = text + Profile.Country+" ";
			}

			if(Profile.City == null || Profile.City == "")
			{
				text = text + "null ";
			}
			else
			{
				text = text + Profile.City+" ";
			}

			if (Profile.AboutMe == null || Profile.AboutMe == "")
			{
				text = text + "null ";
			}
			else
			{
				text = text+ Profile.AboutMe+" ";
			}

			if(Profile.LinkedInUrl == null || Profile.LinkedInUrl == "")
			{
				text = text + " null ";
			}
			else
			{
				text = text + Profile.LinkedInUrl+" ";
			}

			if (Profile.IsOpenToWork == null || Profile.IsOpenToWork == false)
			{
				text = text + "false";
			}
			else
			{
				text = text + "true";
			}
			return text;
		}
		private void Cleaner()
		{
			Profile.Email = "";
			Profile.FirstName = "";
			Profile.LastName = "";
			Profile.PhoneNumber = "";
			Profile.Gender = "";

			Profile.BirthDate = "";
			Profile.AboutMe = "";
			Profile.City = "";
			Profile.Country = "";
			Profile.LinkedInUrl = "";
			Profile.IsOpenToWork = false;
		}
		private void voidAdder()
		{
			if (Profile.City == null)
			{
				Profile.City = "null";
			}
			if(Profile.Country == null)
			{
				Profile.Country = "null";
			}
			if(Profile.AboutMe == null)
			{
				Profile.AboutMe = "null";
			}
			if(Profile.BirthDate == null)
			{
				Profile.BirthDate = "null";
			}
			if(Profile.LinkedInUrl == null)
			{
				Profile.LinkedInUrl = "null";
			}
		}

		public RegisterPageModel(ProfileInterface profileInterface)
		{
			_profileInterface = profileInterface;
		}

		public void OnPostSave()
        {
			if(ErrorChecher() == false)
			{
				return;
			}
			voidAdder();
			_profileInterface.AddProfile(Profile);
			Succses = "Succses";
        }
        public void OnPostDelete()
        {
			Cleaner();

			ModelState.Clear();
			ErrorChecher();
		}

        public void OnGet()
        {
            Profile = new Profile();
			Cleaner();

			Succses = "";

			ErrorChecher();
		}
    }
}
