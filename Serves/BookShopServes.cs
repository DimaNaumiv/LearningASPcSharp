using Claswork_ASP_APP.MyClasses;
using Copy_Classwork_APS_APP.DAL.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text;
using Copy_Classwork_APS_APP.DAL.Models;

namespace Claswork_ASP_APP.Serves
{
	public class BookShopServes : IBookShopServes
	{
		public IBookShopRepository _bookShop;
        public BookShopServes(IBookShopRepository bookShopRepository)
        {
			_bookShop = bookShopRepository;
		}
		private bool ErrorChacher(AuthorBook avthorBook, char type)
		{
			if (avthorBook.AFirstName_BTitle == "" || avthorBook.AFirstName_BTitle == null)
			{
				//Error = "you missed task 1";
				return false;
			}
			if (avthorBook.ALastName_BISBN == "" || avthorBook.ALastName_BISBN == null)
			{
				//Error = "you missed task 2";
				return false;
			}
			else
			{
				if (type == 'b')
				{
					if (avthorBook.ALastName_BISBN.Length < 5)
					{
						//Error = "ISBN have smaller than 5 sibols";
						return false;
					}
					StringBuilder sb = new StringBuilder();
					for (int i = 0; i < 4; i++)
					{
						sb.Append(avthorBook.ALastName_BISBN[i]);
					}
					if (sb.ToString() != "978-")
					{
						//Error = "wrong inputed ISBN it mast start with 978-";
						return false;
					}
				}

			}
			if (avthorBook.ABirthDate_BPublishedYear == null)
			{
				//Error = "you missed task 3";
				return false;
			}
			else
			{
				if (avthorBook.ABirthDate_BPublishedYear < 1450)
				{
					//Error = "you cant input year smaller than 1450";
					return false;
				}
				else if (avthorBook.ABirthDate_BPublishedYear > 2026)
				{
					//Error = "you cant input year bigger than 2026";
					return false;

				}
			}
			if (type == 'b')
			{
				if (avthorBook.BPrice < 0)
				{
					//Error = "Your book cant cost smaller than 0";
					return false;
				}
			}
			return true;
		}
		private Author MapToAvtor(AuthorBook authorBook)
		{
			return new Author
			{
				FirstName = authorBook.AFirstName_BTitle,
				LastName = authorBook.ALastName_BISBN,
				BirthDate = authorBook.ABirthDate_BPublishedYear
			};
		}
		private Book MapToBook(AuthorBook authorBook)
		{
			return new Book
			{
				Title = authorBook.AFirstName_BTitle,
				ISBN = authorBook.ALastName_BISBN,
				PublisherYear = authorBook.ABirthDate_BPublishedYear,
				Price = authorBook.BPrice,
				authorId = authorBook.AId
			};
		}
		private AuthorBook MapToAvtorBook(Author? author,Book? book)
		{
			AuthorBook authorBook = new AuthorBook();
			if (author != null)
			{
				authorBook.AFirstName_BTitle = author.FirstName;
				authorBook.ALastName_BISBN = author.LastName;
				authorBook.ABirthDate_BPublishedYear = author.BirthDate;
				return authorBook;
			}
			authorBook.AFirstName_BTitle = book.Title;
			authorBook.ALastName_BISBN = book.ISBN;
			authorBook.ABirthDate_BPublishedYear = book.PublisherYear;
			authorBook.BPrice = book.Price;
			authorBook.AId = book.authorId;
			return authorBook;
		}
		public List<AuthorBook> GetAllAuthors()
		{
			List<AuthorBook> authors = new List<AuthorBook>();
			foreach(var avtor in _bookShop.GetAllAuthors())
			{
				authors.Add(MapToAvtorBook(avtor,null));
			}
			return authors;
		}

		public List<AuthorBook> GetAllBooks()
		{
			List<AuthorBook> books = new List<AuthorBook>();
			foreach (var book in _bookShop.GetAllBooks())
			{
				books.Add(MapToAvtorBook(null, book));
			}
			return books;
		}

		public bool SaveAuthor(AuthorBook authorDTO)
		{
			if (ErrorChacher(authorDTO,'a') == false)
			{
				return false;
			}
			_bookShop.AddAuthor(MapToAvtor(authorDTO));
			return true;
		}

		public bool SaveBook(AuthorBook bookDTO)
		{
			if (ErrorChacher(bookDTO,'b') == false)
			{
				return false;
			}
			_bookShop.AddBook(MapToBook(bookDTO));
			return true;
		}
	}
}
