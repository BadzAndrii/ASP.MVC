using Lab2Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2Server.Mappers
{
    public static class BookMapper
    {
        public static Book MapFromModel(this BookModel model, Book book, List<Sage> authors)
        {
            book.Name = model.Name;
            book.Year = model.Year;
            book.Description = model.Description;
            book.Sages = authors;

            return book;
        }

        public static BookModel MapToBookModel(this Book book)
        {
            return new BookModel
            {
                Id = book.Id,
                Description = book.Description,
                Name = book.Name,
                Year = book.Year,
                Authors = string.Join("; ", book.Sages.Select(x => x.Name))
            };
        }

        public static ListBookModels MapTolistBookModel(this List<Book> books, Dictionary<int,string> authorsDictionary)
        {
            var model = new ListBookModels();

            foreach (var item in authorsDictionary)
                model.ListAuthors.Add(item.Key, item.Value);

            model.Books.AddRange(books.Select(x => new BookModel { Name = x.Name, Id = x.Id, Year = x.Year, Authors = string.Join(", ", x.Sages.Select(y => y.Name)), Description = x.Description }));

            return model;
        }
    }
}