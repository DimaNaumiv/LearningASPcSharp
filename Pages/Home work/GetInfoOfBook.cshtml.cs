using Claswork_ASP_APP.MyClasses;
using Claswork_ASP_APP.Serves;
using Copy_Classwork_APS_APP.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace Claswork_ASP_APP.Pages
{
    public class GetInfoOfBookModel : PageModel
    {
        [BindProperty]
        public string window_type { get; set; }
        [BindProperty]
        public string Title { get; set; }
		[BindProperty]
		public string Input_text { get; set; }
		public IBookShopServes _bookServes;
		public List<AuthorBook> avtorBook { get; set; }
        public GetInfoOfBookModel(IBookShopServes bookShopServes)
        {
			_bookServes = bookShopServes;
			avtorBook = new List<AuthorBook>();
			avtorBook = _bookServes.GetAllBooks();
		}
        [BindProperty]
        public string sortType { get; set; }
		private void setAvtorBook()
		{
			if (window_type == "Author")
			{
				if (avtorBook.Count() != 0)
				{
					avtorBook.Clear();
				}
				avtorBook = _bookServes.GetAllAuthors();

			}
			else
			{
				if (avtorBook.Count() != 0)
				{
					avtorBook.Clear();
				}
				avtorBook = _bookServes.GetAllBooks();
			}
		}
        public void OnPostConfirm()
		{
			if (window_type == "Author")
			{
				window_type = "Author";
				Title = "Authors";
				setAvtorBook();

			}
			else
			{
				window_type = "Book";
				Title = "Books";
				setAvtorBook();
			}
		}
        public void OnPostSort()
        {
			setAvtorBook();
            switch (sortType) {
                case "ASD":
					avtorBook = avtorBook.OrderBy(i => i.AFirstName_BTitle).ToList();
                    return;
				case "DESC":
					avtorBook = avtorBook.OrderByDescending(i => i.AFirstName_BTitle).ToList();
					return;
				case "YEAR":
					avtorBook = avtorBook.OrderByDescending(i => i.ABirthDate_BPublishedYear).ToList();
					return;
				case "ID":
					avtorBook = avtorBook.OrderByDescending(i => i.AId).ToList();
					return;
			}

        }
		public void OnPostFind()
		{
			setAvtorBook();
			if(Input_text == "" || Input_text == null)
			{
				return;
			}
			List<AuthorBook> list = new List<AuthorBook>();
			StringBuilder sb = new StringBuilder();
			foreach(var i in avtorBook)
			{
				for(int j = 0; j < Input_text.Length; j++)
				{
					sb.Append(i.AFirstName_BTitle[j]);
				}
				if(Input_text == sb.ToString())
				{
					list.Add(i);
					sb.Clear();
				}
				else
				{
					sb.Clear();
				}
			}
			avtorBook = list;
		}
        public void OnGet()
        {
            window_type = "Book";
            Title = "Books";
            avtorBook = new List<AuthorBook>();
			setAvtorBook();
        }
    }
}
