using System.Web.Mvc;
using Lab2Server.Entities;
using Lab2Server.Repositories;

namespace Lab2Server.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IRepository<Book> _repository;

        public ShoppingCartController(IRepository<Book> repository)
        {
            _repository = repository;
        }

        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }
    }
}