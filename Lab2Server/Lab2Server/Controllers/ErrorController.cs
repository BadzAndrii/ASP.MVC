using System.Web.Mvc;

namespace Lab2Server.Controllers
{
    [HandleError]
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View("Error");
        }

        public ActionResult Unauthorized()
        {
            ViewBag.IconClass = "shield";
            ViewBag.Message = "401 - Unauthorized";

            return View("Error");
        }

        public ActionResult NotFound()
        {
            ViewBag.IconClass = "search";
            ViewBag.Message = "404 - page not found";

            return View("Error");
        }

        public ActionResult AccessDenied()
        {
            ViewBag.IconClass = "shield";
            ViewBag.Message = "Access Denied";

            return View("Error");
        }

        public ActionResult ServerError()
        {
            ViewBag.IconClass = "times-circle";
            ViewBag.Message = "500 - Internal Server error";

            return View("Error");
        }
    }
}