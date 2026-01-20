using Claswork_ASP_APP.MyClasses;
using Claswork_ASP_APP.Serves;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Claswork_ASP_APP.Pages.Home_work
{
    public class AuthorInfoModel : PageModel
    {
        [BindProperty]
        public int authorId { get; set; }
        [BindProperty]
        public AuthorBook Author { get; set; }
        [BindProperty]
        public List<AuthorBook> books { get; set; }
        public IBookShopServes _bookShop { get; set; }
        public AuthorInfoModel(IBookShopServes bookShop)
        {
            _bookShop = bookShop;
            if(Author == null)
            {
                Author = _bookShop.GetAllAuthors().First();
                books = _bookShop.GetAllBooksByAuthorId(Author.AId);
            }
            Author = Author;
        }
        public void OnPostConfirm()
        {
            Author = _bookShop.GetAllAuthors().FirstOrDefault(a => a.AId == authorId);
			books = _bookShop.GetAllBooksByAuthorId(Author.AId);
		}

		public void OnGet(int? id)
        {
			if(id == null)
            {
                Author = _bookShop.GetAllAuthors().First();
                books = _bookShop.GetAllBooksByAuthorId(Author.AId);
                return;
            }
            Author = _bookShop.GetAllAuthors().FirstOrDefault(a=>a.AId == id);
            books = _bookShop.GetAllBooksByAuthorId(id.Value);
        }
    }
}
