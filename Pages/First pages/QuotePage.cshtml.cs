using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Claswork_ASP_APP.MyClasses;

namespace Claswork_ASP_APP.Pages
{
    public class QuotePageModel : PageModel
    {
        List<Quote> quotes = new List<Quote>();

        public string Text { get; set; }
        public string Author { get; set; }
        public string AuthorImage { get; set; }

        public QuotePageModel()
        {
            Quote quo = new Quote();
            quo.quote = "He who has a why to live for can bear almost any how.";
            quo.autor_name = "Friedrich Wilhelm Nietzsche";
            quo.autor_image = "https://th.bing.com/th/id/R.bf82d8b3eb4bf1ec1af8eee2b4cea58e?rik=nRXBwd0ZYo26Tg&pid=ImgRaw&r=0";

            quotes.Add(quo);
            quo = new Quote();

            quo.quote = "Success is not final, failure is not fatal: it is the courage to continue that counts.";
			quo.autor_name = "Winston Churchill";
			quo.autor_image = "https://tse1.mm.bing.net/th/id/OIP.d3TZL2Ij7lsD5FeGJ2GJVgHaLH?rs=1&pid=ImgDetMain&o=7&rm=3";

            quotes.Add(quo);
            quo = new Quote();

            quo.quote = "Be yourself; everyone else is already taken.";
			quo.autor_name = "Oscar Wilde";
			quo.autor_image = "https://th.bing.com/th/id/R.71c580a8d620182f767437a7bbabfc3d?rik=LJEWxEQILLQFNg&pid=ImgRaw&r=0";

            quotes.Add(quo);
            quo = new Quote();
        }
        public void OnGet()
        {
            Quote quo = new Quote();
            Random number = new Random();
            int lenth = quotes.Count;
            quo = quotes[number.Next(0, lenth)];

            Text = quo.quote;
            Author = quo.autor_name;
            AuthorImage = quo.autor_image;
        }
    }
}
