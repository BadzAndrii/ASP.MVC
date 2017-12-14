using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Lab2Server.Mappers;
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
            var ids = GetCartItemIds();
            var model = ShoppingCartMapper.ToShoppingCartModel(_repository.Get(ids), GetUserCart());

            return View(model);
        }

        public ActionResult AddToCart(int bookId, int count)
        {
            if (bookId > 0)
            {
                
                var userCart = GetUserCart() ?? new Dictionary<int, int>();

                if (userCart.ContainsKey(bookId))
                    userCart[bookId] += count;
                else
                    userCart.Add(bookId, count);

                SetUserCart(userCart);
            }

            return Redirect("/Books/Index");
        }

        public ActionResult Edit(int bookId, int count)
        {
            var userCart = GetUserCart() ?? new Dictionary<int, int>();

            if (bookId > 0 && userCart.ContainsKey(bookId))
            {
                userCart[bookId] = count;

                SetUserCart(userCart);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Remove(int bookId)
        {
            var userCart = GetUserCart() ?? new Dictionary<int, int>();

            if (bookId > 0 && userCart.ContainsKey(bookId))
            {
                userCart.Remove(bookId);

                SetUserCart(userCart);
            }

            return RedirectToAction("Index");
        }
    }
}