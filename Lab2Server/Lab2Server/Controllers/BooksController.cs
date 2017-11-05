using Lab2Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Lab2Server.Controllers
{
    
    public class BooksController : Controller
    {
        private readonly DataContext dataContext = new DataContext();

        // GET: Book
        public ActionResult List()
        {
            dataContext.Books.Include(b => b.Sages).Load();
            var books = dataContext.Books.ToList(); // All books with authors
            
            var model = books.Select(x => new BookModel { Name = x.Name, Id = x.Id, Year = x.Year, Authors = string.Join(", " , x.Sages.Select(y=> y.Name)), Description = x.Description });         
            return View(model);
        }
    }
}