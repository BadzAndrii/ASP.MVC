using System.Web.Mvc;
using Lab2Server.Repositories;

namespace Lab2Server.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly ISageRepository _sagesRepository;

        public AuthorsController(ISageRepository sagesRepository)
        {
            _sagesRepository = sagesRepository;
        }

        [HttpGet, Authorize]
        public ActionResult Index()
        {
            return View("Admin");
        }
    }
}