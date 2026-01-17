using Claswork_ASP_APP.MyClasses;
using Claswork_ASP_APP.Serves;
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
        public string Error { get; set; }
        public IBookShopServes _bookServes;
        public AddBookInfoModel(IBookShopServes bookShopServes)
        {
            questions = new TextModel();
			avthorBook = new AuthorBook();
            Error = "";
            _bookServes = bookShopServes;
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
        public void OnPostConfirm()
        {
            SetQuestion();
        }
        public void OnPostSave()
        {
            if(window_type == "Author")
            {
                if (_bookServes.SaveAuthor(avthorBook) == false)
                {
					Error = _bookServes.GetError();
					SetQuestion();
					return;
                }
                SetQuestion();
				Error = "Succses";
				return;
            }
            if (_bookServes.SaveBook(avthorBook) == false)
            {
				Error = _bookServes.GetError();
				SetQuestion();
				return;
            }
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
