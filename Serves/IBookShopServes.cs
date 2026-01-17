using Claswork_ASP_APP.MyClasses;

namespace Claswork_ASP_APP.Serves
{
	public interface IBookShopServes
	{
		public bool SaveAuthor(AuthorBook authorDTO);
		public bool SaveBook(AuthorBook bookDTO);
		public string GetError();
		public List<AuthorBook> GetAllAuthors();
		public List<AuthorBook> GetAllBooks();
	}
}
