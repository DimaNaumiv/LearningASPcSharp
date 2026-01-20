using Claswork_ASP_APP.MyClasses;
using Claswork_ASP_APP.Serves;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Claswork_ASP_APP.Pages.Home_work
{
    public class AuthorInfoModel : PageModel
    {
        public int authorId { get; set; }
        public AuthorBook Author { get; set; }
        public IBookShopServes _bookShop { get; set; }
        public AuthorInfoModel(IBookShopServes bookShop)
        {
            _bookShop = bookShop;
            if(Author == null)
            {
                Author = _bookShop.GetAllAuthors().First();
            }
            Author = Author;
        }
        public void OnPostConfirm()
        {
            Author = _bookShop.GetAllAuthors().FirstOrDefault(a => a.AId == authorId);
            OnGet();
        }

		public void OnGet()
        {
			Author = Author;
		}
    }
}
