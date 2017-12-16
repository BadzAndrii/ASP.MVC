using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

using Lab2Server.Models;
using Lab2Server.Entities;
using Lab2Server.Extensions;
using Lab2Server.Comparers;

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

            book.Sages.AddRangeExceptExisting(authors, new KeyEqulityComparer());
            book.Photo = model.PhotoUpload?.InputStream.ToBlob() ?? book.Photo;

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
                Photo = book.Photo?.ToImageSource() ?? "/Content/no-book-preview.png"
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
                Authors = new MultiSelectList(authors.Select(a => new SelectListItem { Value = a.Key.ToString(), Text = a.Value, Selected = book.Sages.Any(s => s.Id == a.Key) } )),
                Photo = book.Photo?.ToImageSource() ?? "/Content/no-book-preview.png"
            };
        }

        public static List<BookModel> MapToListBookModel(this List<Book> books)
        {
            return books.Select( b => b.MapToBookModel(b.Sages.Select(s => s.Name)) ).ToList();
        }

        public static dynamic MapToDynamiBookModel(this Book book, IDictionary<int, string> authors)
        {
            return new
            {
                Id = book.Id,
                Year = book.Year,
                Name = book.Name,
                Description = book.Description,
                Photo = book.Photo?.ToImageSource() ?? "/Content/no-book-preview.png",
                Authors = authors.Select(a => new { Value = a.Key.ToString(), Text = a.Value, Selected = book.Sages.Any(s => s.Id == a.Key) }),
            };
        }
    }
}