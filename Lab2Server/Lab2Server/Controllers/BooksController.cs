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
            return View(ListBooks(page.Value, count.Value));
        }

        //FOR ADMIN
        [Authorize, HttpGet]
        public ActionResult Admin(int? page = 1, int? count = 10)
        {
            return View(ListBooks(page.Value, count.Value));
        }

        [Authorize]
        public ActionResult Create()
        {
            var model = new Book().MapToEditBookModel(_sagesRepository.GetAuthorsDictionary());

            return View("Edit", model);
        }

        [Authorize, HttpGet]
        public ActionResult Edit(int id)
        {
            var authors = _sagesRepository.GetAuthorsDictionary();

            var model = _booksRepository.Get(id).MapToEditBookModel(authors);
            
            return View(model);
        }

        [Authorize, HttpPost]
        public ActionResult Edit(EditBookModel model)
        {
            if (ModelState.IsValid)
            {
                var selectedAuthors = _sagesRepository.Get((model.SelectedAuthorsIds as IEnumerable<int>).ToArray());
                var book = model.MapToBook(_booksRepository.Get(model.Id) ?? new Book(), selectedAuthors);

                _booksRepository.Save(book);

                return RedirectToAction("Admin");
            }

            return View(model);
        }

        [Authorize, HttpGet]
        public ActionResult Delete(int id)
        {
            _booksRepository.Delete(id);

            return RedirectToAction("Admin");
        }

        private PaginationModel<BookModel> ListBooks(int page, int count)
        {
            
            var totalBooks = _booksRepository.Count();
            var totalPages = totalBooks > count
                           ? (totalBooks % count) > 0 ? (totalBooks / count) + 1 : totalBooks / count
                           : 1;

            return new PaginationModel<BookModel>
            {
                Current = page,
                Total = totalPages,
                PageItems = _booksRepository.List(page, count).MapToListBookModel()
            };
        }
    }
}