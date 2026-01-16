using Claswork_ASP_APP.MyClasses;
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
        public IBookShopRepository bookShop { get; set; }
        public List<AuthorBook> avtorBook { get; set; }
        public GetInfoOfBookModel(IBookShopRepository _bookShop)
        {
            bookShop = _bookShop;
			avtorBook = new List<AuthorBook>();
			foreach (var i in bookShop.GetAllBooks())
			{
				AuthorBook ab = new AuthorBook();
				ab.AFirstName_BTitle = i.Title;
				ab.ALastName_BISBN = i.ISBN;
				ab.ABirthDate_BPublishedYear = i.PublisherYear;
				ab.BPrice = i.Price;
				ab.AId = i.Id;
				avtorBook.Add(ab);
			}
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
				foreach (var i in bookShop.GetAllAuthors())
				{
					AuthorBook ab = new AuthorBook();
					ab.AFirstName_BTitle = i.FirstName;
					ab.ALastName_BISBN = i.LastName;
					ab.ABirthDate_BPublishedYear = i.BirthDate;
					ab.AId = i.Id;
					avtorBook.Add(ab);
				}

			}
			else
			{
				if (avtorBook.Count() != 0)
				{
					avtorBook.Clear();
				}
				foreach (var i in bookShop.GetAllBooks())
				{
					AuthorBook ab = new AuthorBook();
					ab.AFirstName_BTitle = i.Title;
					ab.ALastName_BISBN = i.ISBN;
					ab.ABirthDate_BPublishedYear = i.PublisherYear;
					ab.BPrice = i.Price;
					ab.AId = i.Id;
					avtorBook.Add(ab);
				}
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
