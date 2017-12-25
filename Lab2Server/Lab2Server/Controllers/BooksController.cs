using System.Web.Mvc;
using Lab2Server.Repositories;
using Lab2Server.Entities;

namespace Lab2Server.Controllers
{
    public class BooksController : Controller
    {
        private readonly ISageRepository _sagesRepository;
        private readonly IRepository<Book> _booksRepository;

        public BooksController(ISageRepository sagesRepository, IRepository<Book> booksRepository)
        {
            _sagesRepository = sagesRepository;
            _booksRepository = booksRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(User.Identity.IsAuthenticated ? "Admin" : "Shop");
        }
    }
}