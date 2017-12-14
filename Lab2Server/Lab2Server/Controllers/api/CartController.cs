using System.Linq;
using System.Web.Http;
using System.Collections.Generic;

using Lab2Server.Mappers;
using Lab2Server.Entities;
using Lab2Server.Repositories;
using System.Web.SessionState;
using System.Web;
using System.Net.Http;
using System.Net;

namespace Lab2Server.Controllers.api
{
    public class CartController : ApiController
    {
        IRepository<Book> _repository;
        protected HttpSessionState Session => HttpContext.Current.Session;

        public CartController(IRepository<Book> repository)
        {
            _repository = repository;
        }

        // GET: api/Cart
        public IEnumerable<string> Get()
        {
            var ids = GetCartItemIds();
            var entities = _repository.Get(ids);

            return ShoppingCartMapper.ToShoppingCartJSON(entities, GetUserCart());
        }

        // POST: api/Cart INSERT
        public void Post(int id)
        {
            if (id > 0)
            {
                var userCart = GetUserCart() ?? new Dictionary<int, int>();

                if (userCart.ContainsKey(id))
                    userCart[id] += 1;
                else
                    userCart.Add(id, 1);

                SetUserCart(userCart);
            }
        }

        // PUT: api/Cart/5 UPDATE
        public HttpResponseMessage Put(int id, [FromBody]int count)
        {
            bool exists;
            var userCart = GetUserCart() ?? new Dictionary<int, int>();

            if (exists = (id > 0 && userCart.ContainsKey(id)))
            {
                userCart[id] = count;

                SetUserCart(userCart);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            
            // remove from UI list
            return Request.CreateResponse(HttpStatusCode.Gone, new { doesObjExist = exists });
        }

        // DELETE: api/Cart/5
        public void Delete(int id)
        {
            var userCart = GetUserCart() ?? new Dictionary<int, int>();

            if (id > 0 && userCart.ContainsKey(id))
            {
                userCart.Remove(id);

                SetUserCart(userCart);
            }
        }

        #region private members

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

        #endregion
    }
}
