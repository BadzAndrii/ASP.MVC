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
        public ActionResult List(int? page = 1, int? count = 10)
        {
            return View(List(page, count));
        }

        //FOR ADMIN
        [Authorize, HttpGet]
        public ActionResult AdminList(int? page = 1, int? count = 10)
        {
            return View(List(page, count));
        }

        [Authorize, HttpPost]
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
                var selectedAuthors = _sagesRepository.Get((model.Authors.SelectedValues as IEnumerable<int>).ToArray());
                var book = model.MapToBook(_booksRepository.Get(model.Id), selectedAuthors);

                _booksRepository.Save(book);

                return Redirect("AdminList");
            }

            return View(model);
        }

        [Authorize, HttpGet]
        public ActionResult Delete(int id)
        {
            _booksRepository.Delete(id);

            return Redirect("AdminList");
        }

        private List<BookModel> List(int page, int count)
        {
            return _booksRepository.List(page, count).MapToListBookModel();
        }
    }
}