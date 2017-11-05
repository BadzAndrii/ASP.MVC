using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2Server.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult List()
        {
            return View();
        }
    }
}