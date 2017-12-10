using System.Linq;
using System.Collections.Generic;

using Lab2Server.Models;
using Lab2Server.Entities;

namespace Lab2Server.Mappers
{
    public static class ShoppingCartMapper
    {
        public static ShoppingCartModel ToShoppingCartModel(IEnumerable<Book> books, IDictionary<int,int> bookIdQuantity)
        {
            var shoppingList = bookIdQuantity
                    .Select(b => MapToShoppingCartItem(b.Key, b.Value, books.Single(x => x.Id == b.Key)))
                    .ToList();

            return new ShoppingCartModel { ShoppingList = shoppingList };
        }

        private static ShoppingItemModel MapToShoppingCartItem(int bookId, int count, Book book)
        {
            return new ShoppingItemModel
            {
                Count = count,
                Book = BookModelMapper.MapToBookModel(book, book.Sages.Select(b => b.Name))
            };
        }
    }
}