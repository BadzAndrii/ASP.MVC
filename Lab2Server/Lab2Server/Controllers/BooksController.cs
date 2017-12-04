using Lab2Server.Models;
using System.Web.Mvc;
using Lab2Server.Repositories;

namespace Lab2Server.Controllers
{
    public class BooksController : Controller
    {
        private readonly IRepository<BookModel, ListBookModels> _booksRepository;

        public BooksController(IRepository<BookModel, ListBookModels> booksRepository)
        {
            _booksRepository = booksRepository;
        }

        // GET: Book
        public ActionResult List()
        {
            return View(_booksRepository.GetList());
        }

        [Authorize, HttpPost]
        public ActionResult Create(ListBookModels model)
        {
            _booksRepository.Save(model);

            return Redirect("AdminList");
        }
        
        //FOR ADMIN
        [Authorize]
        public ActionResult AdminList()
        {
            return View(_booksRepository.GetAdminList());
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            _booksRepository.Delete(id);

            return Redirect("AdminList");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            return View(_booksRepository.Get(id));
        }

        //[Authorize, HttpPost]
        //public ActionResult Edit(BookModel model)
        //{
        //    _booksRepository.Save(model);
        //    return Redirect("AdminList");
        //}
    }
}