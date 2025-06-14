using Microsoft.AspNetCore.Mvc;

namespace lab2.Controllers
{
    public class StateController : Controller
    {

        //session
        public IActionResult SetSession(string name, string email)
        {
            HttpContext.Session.SetString("name", name);
            HttpContext.Session.SetString("email", email);

            return Content($"Session Save");

        }

        public IActionResult GetSession()
        {
           string name= HttpContext.Session.GetString("name");
           string email= HttpContext.Session.GetString("email");

            return Content($"Session :{name} {email}");

        }


        //cookies
        public IActionResult SetCookie(string name, string email)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTimeOffset.Now.AddDays(2);
            HttpContext.Response.Cookies.Append("name", name, options);
            HttpContext.Response.Cookies.Append("email", email, options);
            return Content("cookie saved");
        }

        public IActionResult GetCookie()
        {
            string name = HttpContext.Request.Cookies["name"];
            string email=HttpContext.Request.Cookies["email"];
            return Content($"Cookie {name}\n {email}");

        }
    }
    }
