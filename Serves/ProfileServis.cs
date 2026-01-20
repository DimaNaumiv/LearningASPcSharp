using Claswork_ASP_APP.MyClasses;
using Copy_Classwork_APS_APP.DAL.Interfaces;
using Copy_Classwork_APS_APP.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Claswork_ASP_APP.Serves
{
	public class ProfileServis : IProfileServis
	{
		private ProfileInterface _profileInterface;
		private bool ErrorChecher(ProfileDTO Profile)
		{
			if (Profile.FirstName == "" || Profile.FirstName == null)
			{
				//Error = "First name is empty";
				return false;
			}
			else if (Profile.FirstName.Length < 2)
			{
				//Error = "First name is smoler then 2 simbols";
				return false;
			}

			if (Profile.LastName == "" || Profile.LastName == null)
			{
				//Error = "Last name is empty";
				return false;
			}
			else if (Profile.LastName.Length < 2)
			{
				//Error = "Last name is smoler then 2 simbols";
				return false;
			}

			if (Profile.Email == "" || Profile.Email == null)
			{
				//Error = "Email is empty";
				return false;
			}

			if (Profile.PhoneNumber == "" || Profile.PhoneNumber == null)
			{
				//Error = "phone number is empty";
				return false;
			}

			if (Profile.Gender == "" || Profile.Gender == null)
			{
				//Error = "gender is empty";
				return false;
			}

			//Error = "";
			return true;
		}
		private void voidAdder(ProfileDTO Profile)
		{
			if (Profile.City == null)
			{
				Profile.City = "null";
			}
			if (Profile.Country == null)
			{
				Profile.Country = "null";
			}
			if (Profile.AboutMe == null)
			{
				Profile.AboutMe = "null";
			}
			if (Profile.BirthDate == null)
			{
				Profile.BirthDate = "null";
			}
			if (Profile.LinkedInUrl == null)
			{
				Profile.LinkedInUrl = "null";
			}
		}
		private ProfileDTO MapToDto(Profile profile)
		{
			return new ProfileDTO
			{
				FirstName = profile.FirstName,
				LastName = profile.LastName,
				Gender = profile.Gender,
				Email = profile.Email,
				PhoneNumber = profile.PhoneNumber,
				Id = profile.Id,
				LinkedInUrl = profile.LinkedInUrl,
				IsOpenToWork = profile.IsOpenToWork,
				BirthDate = profile.BirthDate,
				Country = profile.Country,
				City = profile.City,
				AboutMe = profile.AboutMe
			};
		}

		public ProfileServis(ProfileInterface profileInterface)
        {
			_profileInterface = profileInterface;
		}
        public List<ProfileDTO> GetAll()
		{
			var users = _profileInterface.GetAll();
			List<ProfileDTO> DtoProfile = new List<ProfileDTO>();
			foreach (var profile in users) {
				DtoProfile.Add(MapToDto(profile));
			}
			return DtoProfile;
		}

		public bool Save(ProfileDTO profile)
		{
			if (ErrorChecher(profile) == false)
			{
				return false;
			}
			voidAdder(profile);
			var user = new Profile()
			{
				FirstName = profile.FirstName,
				LastName = profile.LastName,
				Gender = profile.Gender,
				Email = profile.Email,
				PhoneNumber = profile.PhoneNumber,
				Id = profile.Id,
				LinkedInUrl = profile.LinkedInUrl,
				IsOpenToWork = profile.IsOpenToWork,
				BirthDate = profile.BirthDate,
				Country = profile.Country,
				City = profile.City,
				AboutMe = profile.AboutMe
			};
			_profileInterface.AddProfile(user);
			return true;
		}
		public ProfileDTO GetLastProfile()
		{
			var profile = _profileInterface.GetAll().LastOrDefault();
			return MapToDto(profile);
		}
		public ProfileDTO GetFirstProfile() {
			var profile = _profileInterface.GetAll().FirstOrDefault();
			return MapToDto(profile);
		}
		public ProfileDTO GetById(int ID)
		{
			return MapToDto(_profileInterface.GetProfileById(ID));
		}
	}
}
