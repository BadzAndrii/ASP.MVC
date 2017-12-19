using Lab2Server.Models;
using System.Web.Mvc;
using Lab2Server.Repositories;
using Lab2Server.Mappers;
using Lab2Server.Entities;
using System.Collections.Generic;
using System.Linq;

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
            return RedirectToAction(User.Identity.IsAuthenticated ? "Admin" : "Shop");
        }

        [HttpGet]
        public ActionResult Shop(int? page = 1, int? count = 10)
        {
            return View();
        }

        //FOR ADMIN
        [Authorize, HttpGet]
        public ActionResult Admin(int? page = 1, int? count = 10)
        {
            return View();
        }
    }
}