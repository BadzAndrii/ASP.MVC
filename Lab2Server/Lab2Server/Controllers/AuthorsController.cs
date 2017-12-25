using System.Web.Mvc;

namespace Lab2Server.Controllers
{
    public class AuthorsController : Controller
    {
        [HttpGet, Authorize]
        public ActionResult Index()
        {
            return View("Admin");
        }
    }
}