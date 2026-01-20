using Claswork_ASP_APP.MyClasses;

namespace Claswork_ASP_APP.Serves
{
	public interface IBookShopServes
	{
		public bool SaveAuthor(AuthorBook authorDTO);
		public bool SaveBook(AuthorBook bookDTO);

		public void DalateAuthor(int authorId);
        public void DalateBook(int bookId);
        public void ChangeAuthorInfo(AuthorBook authorDTO);
        public void ChangeBookInfo(AuthorBook bookDTO);

        public string GetError();
		public List<AuthorBook> GetAllAuthors();
		public List<AuthorBook> GetAllBooks();
	}
}
