using System.Collections.Generic;
using System.Web.Mvc;

namespace Lab2Server.Controllers
{
    public class HomeController : Controller
    {
        private readonly Dictionary<string, string> _menu = new Dictionary<string, string>
        {
            { "Login", "/login/index"},
            { "Books", "/books/list" },
            { "Authors", "/authors/list" },
            { "About", "/about/details" },
        };

        // GET: Home
        public ActionResult Index()
        {
            return View(_menu);
        }

        //[HttpPost]
        //public ActionResult Detalis()
        //{
        //    return View("Index", _menu);
        //}
    }
}