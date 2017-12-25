using System.Web.Mvc;

namespace Lab2Server.Controllers
{
    public class BooksController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(User.Identity.IsAuthenticated ? "Admin" : "Shop");
        }
    }
}