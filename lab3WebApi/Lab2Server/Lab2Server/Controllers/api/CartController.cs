using System.Linq;
using System.Web.Http;
using System.Collections.Generic;

using Lab2Server.Models;
using Lab2Server.Mappers;
using Lab2Server.Repositories;

namespace Lab2Server.Controllers.api
{
    public class CartController : ApiController
    {
        IBookRepository _repository;
        public CartController(IBookRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Cart
        public IEnumerable<ShoppingItemModel> Get([FromUri]GetCartData cartData)
        {
            cartData = cartData ?? new GetCartData();

            var ids = cartData.Items.Select(i => i.Id);
            var entities = _repository.Get(ids.ToArray());

            return ShoppingCartMapper.ToShoppingCartModel(entities, cartData.Items);
        }
    }
}
