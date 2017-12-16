using System.Linq;
using System.Web.Http;
using System.Collections.Generic;

using Lab2Server.Models;
using Lab2Server.Mappers;
using Lab2Server.Entities;
using Lab2Server.Repositories;

namespace Lab2Server.Controllers.api
{
    public class CartController : ApiController
    {
        IRepository<Book> _repository;
        public CartController(IRepository<Book> repository)
        {
            _repository = repository;
        }

        // GET: api/Cart
        public IEnumerable<ShoppingItemModel> Get([FromBody] Dictionary<int, int> cartData)
        {
            cartData = cartData ?? new Dictionary<int, int>();

            var ids = cartData.Select(i => i.Key);
            var entities = _repository.Get(ids.ToArray());

            return ShoppingCartMapper.ToShoppingCartModel(entities, cartData);
        }
    }
}
