using System.Linq;
using System.Collections.Generic;

using Lab2Server.Models;
using Lab2Server.Entities;

namespace Lab2Server.Mappers
{
    public static class ShoppingCartMapper
    {
        public static IEnumerable<ShoppingItemModel> ToShoppingCartModel(IEnumerable<Book> books, IEnumerable<CartItem> bookIdQuantity)
        {
            return bookIdQuantity.Select(b => MapToShoppingCartItem(b.Id, b.Count, books.Single(x => x.Id == b.Id)));
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