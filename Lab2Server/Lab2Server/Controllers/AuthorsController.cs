//using System.Linq;
//using System.Web.Mvc;
//using Lab2Server.Models;
//using System.Data.Entity;
//using System.Web;

//namespace Lab2Server.Controllers
//{
//    [Authorize]
//    public class AuthorsController : Controller
//    {
//        private readonly DataContext dataContext = new DataContext();

//        // GET: Authors
//        public ActionResult List()
//        {
//            var model = new ListSageModels();


//            var sages = dataContext
//                .Sages
//                .OrderBy(s => s.Name)
//                .ToList(); //Load ALL Sages in Memory


//            model.Sages.AddRange(sages.Select(s => new SageModel { Name = s.Name, Id = s.Id, Age = s.Age, City = s.City }));
//            return View(model);
//        }

//        //Add image
//        //public ActionResult AddImage()
//        //{
//        //    SageModel b1 = new SageModel();
//        //    return View(b1);
//        //}
//        //End
//        [HttpPost]
//        public ActionResult Create(ListSageModels model)
//        {
//            //model.Photo= new byte[image1.ContentLength];
//            var newSage = new Sage { Name = model.Name, Age = model.Age, City = model.City };

//            dataContext.Sages.Add(newSage);
//            dataContext.SaveChanges();
//            return Redirect("List");
//        }
//    }
//}