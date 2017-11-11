using Lab2Server.Models;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Collections.Generic;

namespace Lab2Server.Controllers
{

    public class BooksController : Controller
    {
        private readonly DataContext dataContext = new DataContext();

        // GET: Book
        public ActionResult List()
        {
            var model = new List<BookModel>();

            dataContext.Books.Include(b => b.Sages).Load(); // All books with authors

            var books = dataContext
                .Books
                .OrderBy(x => x.Name)
                .ToList(); //Load All books in Memory

            var authors = dataContext
                .Sages
                .Select(x => new { Id = x.Id, Name = x.Name })
                .OrderBy(x => x.Name)
                .ToDictionary(key => key.Id, val => val.Name);

            model.AddRange(books.Select(x => new BookModel { Name = x.Name, Id = x.Id, Year = x.Year, Authors = string.Join(", ", x.Sages.Select(y => y.Name)), Description = x.Description }));

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(ListBookModels model)
        {
            var authors = dataContext
                    .Sages.Where(author => model.Authors.Contains(author.Id))
                    .ToList();

            var newBook = new Book { Name = model.Name, Year = model.Year, Description = model.Description, Sages = authors };

            dataContext.Books.Add(newBook);
            dataContext.SaveChanges();

            return Redirect("AdminList");
        }
        //FOR ADMIN
        public ActionResult AdminList()
        {
            var model = new ListBookModels();

            dataContext.Books.Include(b => b.Sages).Load(); // All books with authors

            var books = dataContext
                .Books
                .OrderBy(x => x.Name)
                .ToList(); //Load All books in Memory

            var authors = dataContext
                .Sages
                .Select(x => new { Id = x.Id, Name = x.Name })
                .OrderBy(x => x.Name)
                .ToDictionary(key => key.Id, val => val.Name);

            foreach (var item in authors)
                model.ListAuthors.Add(item.Key, item.Value);

            model.Books.AddRange(books.Select(x => new BookModel { Name = x.Name, Id = x.Id, Year = x.Year, Authors = string.Join(", ", x.Sages.Select(y => y.Name)), Description = x.Description }));

            return View(model);
        }
    }
}