using Claswork_ASP_APP.MyClasses;
using Claswork_ASP_APP.Serves;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Claswork_ASP_APP.Pages.Home_work
{
    public class ChangeBookInfoModel : PageModel
    {
        [BindProperty]
        public AuthorBook Book { get; set; }
        [BindProperty]
        public int bookId { get; set; }
        [BindProperty]
        public string Error { get; set; }
        public IBookShopServes _bookShop { get; set; }
        public ChangeBookInfoModel(IBookShopServes bookShop)
        {
            _bookShop = bookShop;
            if (Book == null)
            {
                Book = _bookShop.GetAllBooks().First();
                return;
            }
            Book = Book;
        }
        public void OnPostConfirm()
        {
            Book = _bookShop.GetAllBooks().FirstOrDefault(a => a.BId == bookId);
            ModelState.Clear();
        }
        public void OnPostChange()
        {
            AuthorBook bookForUpdate = _bookShop.GetAllBooks().FirstOrDefault(b => b.BId == bookId);
            if (bookForUpdate == null)
            {
                Error = "we cant find book";
                return;
            }
            bookForUpdate.BPrice = Book.BPrice;
            bookForUpdate.AFirstName_BTitle = Book.AFirstName_BTitle;
            bookForUpdate.ABirthDate_BPublishedYear = Book.ABirthDate_BPublishedYear;
            _bookShop.ChangeBookInfo(bookForUpdate);
            Error = _bookShop.GetError();
            if(Error == "" || Error == null)
            {
                Error = "Succes";
            }
        }
        public void OnPostDelete()
        {
            _bookShop.DalateBook(bookId);
            Error = _bookShop.GetError();
        }
        public void OnGet()
        {
        }
    }
}
