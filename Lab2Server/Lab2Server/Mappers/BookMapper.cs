using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

using Lab2Server.Models;
using Lab2Server.Entities;
using Lab2Server.Extensions;
using System.IO;

namespace Lab2Server.Mappers
{
    public static class BookMapper
    {
        public static Book MapToBook(this BookModel model, Book book)
        {
            book.Name = model.Name;
            book.Year = model.Year;
            book.Description = model.Description;

            return book;
        }

        public static Book MapToBook(this EditBookModel model, Book book, List<Sage> authors)
        {
            MapToBook(model as BookModel, book);

            book.Sages = authors;

            if(model.PhotoUpload != null)
            {
                using (var memStream = new MemoryStream())
                {
                    model.PhotoUpload.InputStream.CopyTo(memStream);
                    book.Photo = memStream.ToArray();
                }
            }

            return book;
        }
    }

    public static class BookModelMapper
    {
        public static BookModel MapToBookModel(this Book book, IEnumerable<string> authors)
        {
            return new BookModel
            {
                Id = book.Id,
                Year = book.Year,
                Name = book.Name,
                Description = book.Description,
                Authors = string.Join("; ", authors),
                Photo = book.Photo.ToBase64String()
            };
        }

        public static EditBookModel MapToEditBookModel(this Book book, IDictionary<int, string> authors)
        {
            return new EditBookModel
            {
                Id = book.Id,
                Year = book.Year,
                Name = book.Name,
                Description = book.Description,
                Authors = new MultiSelectList(authors.Select(a => new { Value = a.Key, Text = a.Value, Selected = book.Sages.Any(s => s.Id == a.Key) } )),
                Photo = book.Photo.ToBase64String()
            };
        }

        public static List<BookModel> MapToListBookModel(this List<Book> books)
        {
            return books.Select( b => b.MapToBookModel(b.Sages.Select(s => s.Name)) ).ToList();
        }
    }
}