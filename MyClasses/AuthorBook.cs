namespace Claswork_ASP_APP.MyClasses
{
	public class AuthorBook
	{
		public string AFirstName_BTitle { get; set; }
		public string ALastName_BISBN { get; set; }
		public int ABirthDate_BPublishedYear { get; set; }
		public int BPrice { get; set; }
		public int AId { get; set; }
		public int BId { get; set; }
	}
	public abstract class AuthorEdition
	{
		public List<AuthorBook> books;
	}
}
