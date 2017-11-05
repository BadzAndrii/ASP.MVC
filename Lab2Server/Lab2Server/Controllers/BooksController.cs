using Lab2Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2Server.Controllers
{
    
    public class BooksController : Controller
    {
        private readonly DataContext dataContext = new DataContext();

        // GET: Book
        public ActionResult List()
        {
            var model = new List<BookModel>();
            dataContext.Books.Select<B>
            return View(model);
        }
    }
}