using System.Collections.Generic;
using System.Web.Mvc;

namespace Lab2Server.Controllers
{
    public class HomeController : Controller
    {
        private readonly Dictionary<string, string> _menu = new Dictionary<string, string>
        {
            { "Books", "/books/adminlist" },
            { "Authors", "/authors/list" }
        };

        // GET: Home
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(_menu);
            }

            return Redirect("Users/Login");
        }

        public ActionResult Menu()
        {
            return View("_MenuLinks", User.Identity.IsAuthenticated ? _menu : new Dictionary<string, string> { { "Books", "/books/list" } });
        }
    }
}