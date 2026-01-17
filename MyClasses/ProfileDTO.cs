using System.ComponentModel.DataAnnotations;

namespace Claswork_ASP_APP.MyClasses
{
	public class ProfileDTO
	{
		public int Id { get; set; }
		public string BirthDate { get; set; }
		public string Country { get; set; }
		public string City { get; set; }
		[MaxLength(500)]
		public string AboutMe { get; set; }
		public string LinkedInUrl { get; set; }
		public bool IsOpenToWork { get; set; }

		[Required]
		[MinLength(2)]
		public string FirstName { get; set; }
		[Required]
		[MinLength(2)]
		public string LastName { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		[Phone]
		public string PhoneNumber { get; set; }
		public string Gender { get; set; }

	}
}
