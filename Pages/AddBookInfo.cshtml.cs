using Claswork_ASP_APP.MyClasses;
using Copy_Classwork_APS_APP.DAL;
using Copy_Classwork_APS_APP.DAL.Interfaces;
using Copy_Classwork_APS_APP.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace Claswork_ASP_APP.Pages
{
    public class AddBookInfoModel : PageModel
    {
        [BindProperty]
        public string window_type { get; set; }
        [BindProperty]
        public AuthorBook avthorBook { get; set; }
        [BindProperty]
        public TextModel questions { get; set; }
        public IBookShopRepository bookShop;
        public string Error { get; set; }
        public AddBookInfoModel(IBookShopRepository bookShopRepository)
        {
            questions = new TextModel();
			avthorBook = new AuthorBook();
            Error = "";
            bookShop = bookShopRepository;
		}

        private void SetQuestion()
        {
            if(window_type == "Book")
            {
                questions.Task1 = "Input Book title";
                questions.Task2 = "Input Book ISBN";
				questions.Task3 = "Input Book published year";
				questions.Task4 = "Input Book Price";
				questions.Task5 = "Select avtor";
                return;
			}
			questions.Task1 = "Input Author first name";
			questions.Task2 = "Input Author last name";
			questions.Task3 = "Input Author birth day";
            questions.Task4 = "none";
            questions.Task5 = "none";
		}
        private bool ErrorChacher()
        {
            if(avthorBook.AFirstName_BTitle == "" || avthorBook.AFirstName_BTitle == null)
            {
                Error = "you missed task 1";
                return false;
            }
            if(avthorBook.ALastName_BISBN == "" || avthorBook.ALastName_BISBN == null)
            {
                Error = "you missed task 2";
				return false;
			}
            else
            {
                if(window_type == "Book")
                {
                    if (avthorBook.ALastName_BISBN.Length < 5)
                    {
                        Error = "ISBN have smaller than 5 sibols";
                        return false;
                    }
					StringBuilder sb = new StringBuilder();
                    for(int i = 0; i < 4; i++)
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
            if(avthorBook.ABirthDate_BPublishedYear == null)
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
                else if(avthorBook.ABirthDate_BPublishedYear > 2026)
                {
                    Error = "you cant input year bigger than 2026";
                    return false;

				}
            }
            if(window_type == "Book")
            {
                if (avthorBook.BPrice < 0)
                {
                    Error = "Your book cant cost smaller than 0";
                    return false;
                }
            }
            return true;
        }
        public void OnPostConfirm()
        {
            SetQuestion();
        }
        public void OnPostSave()
        {
            if(ErrorChacher() == false)
            {
				SetQuestion();
				return;
            }
            if(window_type == "Author")
            {
                Author author = new Author();
                author.FirstName = avthorBook.AFirstName_BTitle;
                author.LastName = avthorBook.ALastName_BISBN;
                author.BirthDate = avthorBook.ABirthDate_BPublishedYear;
                bookShop.AddAuthor(author);
                SetQuestion();
				Error = "Succses";
				return;
            }
            Book book = new Book();
            book.Title = avthorBook.AFirstName_BTitle;
            book.ISBN = avthorBook.ALastName_BISBN;
            book.PublisherYear = avthorBook.ABirthDate_BPublishedYear;
            book.Price = avthorBook.BPrice;
            book.authorId = avthorBook.AId;
            bookShop.AddBook(book);
            SetQuestion();
            Error = "Succses";
        }
		public void OnGet()
        {
            window_type = "Book";
            SetQuestion();

		}
    }
}
