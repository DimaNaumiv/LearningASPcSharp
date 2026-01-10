using Claswork_ASP_APP.MyClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace Claswork_ASP_APP.Pages
{
    public class ProfilePageModel : PageModel
    {
        public string Message { get; set; }
        public Profile Profile { get; set; }
        public void OnGet()
        {
            Profile = new Profile();
            using (StreamReader sr = new StreamReader("profile.txt"))
            {
                try
                {
                    string text = sr.ReadToEnd();
                    if (text == "")
                    {
                        Message = "You are not registreted";
                        return;
                    }

                    Message = "";

                    StringBuilder sb = new StringBuilder();
                    int number = 0;

                    foreach (char item in text)
                    {
                        if (item != ' ')
                        {
                            sb.Append(item);
                        }
                        else if (item == ' ' || item == '\n')
                        {
                            switch (number)
                            {
                                case 0:
                                    Profile.FirstName = sb.ToString();
                                    break;
                                case 1:
                                    Profile.LastName = sb.ToString();
                                    break;
                                case 2:
                                    Profile.Email = sb.ToString();
                                    break;
                                case 3:
                                    Profile.PhoneNumber = sb.ToString();
                                    break;
                                case 4:
                                    Profile.Gender = sb.ToString();
                                    break;
                                case 5:
									if (sb.ToString().Trim() != "null" || sb.ToString().Trim() != "")
									{
										Profile.BirthDate = sb.ToString();
									}
									else
									{
										Profile.BirthDate = "empty";
									}
									break;
                                case 6:
									if (sb.ToString().Trim() != "null" || sb.ToString().Trim() != "")
									{
										Profile.Country = sb.ToString();
									}
									else
									{
										Profile.Country = "empty";
									}
									break;
                                case 7:
									if (sb.ToString().Trim() != "null" || sb.ToString().Trim() != "")
									{
										Profile.City = sb.ToString();
									}
									else
									{
										Profile.City = "empty";
									}
									break;
                                case 8:
									if (sb.ToString().Trim() != "null" || sb.ToString().Trim() != "")
									{
										Profile.AboutMe = sb.ToString();
									}
									else
									{
										Profile.AboutMe = "empty";
									}
									break;
                                case 9:
                                    if (sb.ToString().Trim() != "null"||sb.ToString().Trim() != "")
                                    {
										Profile.LinkedInUrl = sb.ToString();
									}
                                    else
                                    {
                                        Profile.LinkedInUrl = "empty";
                                    }
                                    break;
                                case 10:
									Profile.IsOpenToWork = bool.Parse(sb.ToString());
                                    break;
                            }
                            number++;
                            sb.Clear();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

        }
    }
}
