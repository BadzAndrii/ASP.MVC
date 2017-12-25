using System.Collections.Generic;
using System.Web.Mvc;

namespace Lab2Server.Controllers
{
    public class HomeController : Controller
    {
        private readonly Dictionary<string, string> _menu = new Dictionary<string, string>
        {
            { "Books", "/books" },
            { "Authors", "/authors" }
        };

        // GET: Home
        public ActionResult Index()
        {
            return Redirect("/Books/Index");
        }

        public ActionResult Menu()
        {
            return View("_MenuLinks", User.Identity.IsAuthenticated ? _menu : new Dictionary<string, string> { { "Books", "/books" } });
        }
    }
}