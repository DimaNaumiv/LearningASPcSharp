using Claswork_ASP_APP.MyClasses;
using Copy_Classwork_APS_APP.DAL.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text;
using Copy_Classwork_APS_APP.DAL.Models;

namespace Claswork_ASP_APP.Serves
{
	public class BookShopServes : IBookShopServes
	{
		private IBookShopRepository _bookShop;
		private string Error { get; set; }
        public BookShopServes(IBookShopRepository bookShopRepository)
        {
			_bookShop = bookShopRepository;
		}
		private bool ErrorChacher(AuthorBook avthorBook, char type)
		{
			if (avthorBook.AFirstName_BTitle == "" || avthorBook.AFirstName_BTitle == null)
			{
				Error = "you missed task 1";
				return false;
			}
			if (avthorBook.ALastName_BISBN == "" || avthorBook.ALastName_BISBN == null)
			{
				Error = "you missed task 2";
				return false;
			}
			else
			{
				if (type == 'b')
				{
					if (avthorBook.ALastName_BISBN.Length < 5)
					{
						Error = "ISBN have smaller than 5 sibols";
						return false;
					}
					StringBuilder sb = new StringBuilder();
					for (int i = 0; i < 4; i++)
					{
						sb.Append(avthorBook.ALastName_BISBN[i]);
					}
					if (sb.ToString() != "978-")
					{
						Error = "wrong inputed ISBN it mast start with 978-";
						return false;
					}
				}

			}
			if (avthorBook.ABirthDate_BPublishedYear == null)
			{
				Error = "you missed task 3";
				return false;
			}
			else
			{
				if (avthorBook.ABirthDate_BPublishedYear < 1450)
				{
					Error = "you cant input year smaller than 1450";
					return false;
				}
				else if (avthorBook.ABirthDate_BPublishedYear > 2026)
				{
					Error = "you cant input year bigger than 2026";
					return false;

				}
			}
			if (type == 'b')
			{
				if (avthorBook.BPrice < 0)
				{
					Error = "Your book cant cost smaller than 0";
					return false;
				}
			}
			return true;
		}
		private Author MapToAvtor(AuthorBook authorBook)
		{
			List<Book> aBooks = new List<Book>();
			foreach(var i in authorBook.books)
			{
				aBooks.Add(MapToBook(i));
			}
			return new Author
			{
				FirstName = authorBook.AFirstName_BTitle,
				LastName = authorBook.ALastName_BISBN,
				BirthDate = authorBook.ABirthDate_BPublishedYear,
				books = aBooks
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
				List<AuthorBook> aBooks = new List<AuthorBook>();
				if (author.books == null)
				{
					aBooks = null;
				}
				else
				{
					foreach (var i in author.books)
					{
						aBooks.Add(MapToAvtorBook(null, i));
					}
				}

				authorBook.AFirstName_BTitle = author.FirstName;
				authorBook.ALastName_BISBN = author.LastName;
				authorBook.ABirthDate_BPublishedYear = author.BirthDate;
				authorBook.AId = author.Id;
				authorBook.books = aBooks;
				return authorBook;
			}
			authorBook.AFirstName_BTitle = book.Title;
			authorBook.ALastName_BISBN = book.ISBN;
			authorBook.ABirthDate_BPublishedYear = book.PublisherYear;
			authorBook.BPrice = book.Price;
			authorBook.AId = book.authorId;
			authorBook.BId = book.Id;
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
		public string GetError()
		{
			return Error;
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

        public void DalateAuthor(int authorId)
		{
			List<Author> authors = _bookShop.GetAllAuthors();
			if(authors == null)
			{
				Error = "We cant find your author";
			}
			if(authors.FirstOrDefault(a=>a.Id == authorId).books != null)
			{
				Error = "You cant delete avthor if has book or books";
				return;
			}
			_bookShop.DeleteAuthor(authorId);
		}
        public void DalateBook(int bookID)
		{
			_bookShop.DeleteBook(bookID);
		}
        public void ChangeAuthorInfo(AuthorBook authorDTO)
		{
            if (ErrorChacher(authorDTO, 'a') == false)
            {
                return;
            }
			if(authorDTO == null)
			{
				Error = "We cant find author";
				return;
			}
			_bookShop.DeleteAuthor(authorDTO.AId);
			_bookShop.AddAuthor(MapToAvtor(authorDTO));
        }
        public void ChangeBookInfo(AuthorBook bookDTO)
		{
            if (ErrorChacher(bookDTO, 'b') == false)
            {
                return;
            }
            _bookShop.DeleteBook(bookDTO.BId);
            _bookShop.AddBook(MapToBook(bookDTO));
        }
    }
}
