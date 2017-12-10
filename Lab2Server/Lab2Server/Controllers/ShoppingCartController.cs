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

        private Dictionary<int, int> GetUserCart()
        {
            return Session[Constants.UserCart] as Dictionary<int, int> ?? new Dictionary<int, int>(0);
        }

        private int[] GetCartItemIds()
        {
            return GetUserCart()?.Select(x => x.Key).ToArray() ?? new int[0];
        }

        private void SetUserCart(Dictionary<int, int> cart)
        {
            Session[Constants.UserCart] = cart;
        }
    }
}