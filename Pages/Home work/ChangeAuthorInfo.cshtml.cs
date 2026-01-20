using Claswork_ASP_APP.MyClasses;
using Claswork_ASP_APP.Serves;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Claswork_ASP_APP.Pages.Home_work
{
    public class ChangeAuthorInfoModel : PageModel
    {
        [BindProperty]
        public AuthorBook Author { get; set; }
        [BindProperty]
        public int authorId { get;set;}
        [BindProperty]
        public string Error { get; set; }
        public IBookShopServes _bookShop { get; set; }
        public ChangeAuthorInfoModel(IBookShopServes bookShop)
        {
            _bookShop = bookShop;
            if(Author == null)
            {
                Author = _bookShop.GetAllAuthors().First();
                return;
            }
            Author = Author;
        }
        public void OnPostConfirm()
        {
            Author = _bookShop.GetAllAuthors().FirstOrDefault(a => a.AId == authorId);
            ModelState.Clear();
        }
        public void OnPostChange()
        {
            Author.AId = authorId;
            _bookShop.ChangeAuthorInfo(Author);
            Error = _bookShop.GetError();
        }
        public void OnPostDelete()
        {
            _bookShop.DalateAuthor(authorId);
            Error = _bookShop.GetError();
        }
        public void OnGet()
        {
        }
    }
}
