using System.Collections.Generic;

namespace Lab2Server.Models
{
    public class ShoppingCartModel
    {
        public List<KeyValuePair<BookModel, int>> ShoppingList { get; set; }
    }
}