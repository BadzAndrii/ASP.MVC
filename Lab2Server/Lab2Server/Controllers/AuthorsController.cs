using Lab2Server.Models;
using System.Web.Mvc;
using Lab2Server.Repositories;
using Lab2Server.Mappers;
using Lab2Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2Server.Controllers
{
    [Authorize]
    public class AuthorsController : Controller
    {
        private readonly ISageRepository _sagesRepository;

        public AuthorsController(ISageRepository sagesRepository)
        {
            _sagesRepository = sagesRepository;
        }

        //FOR ADMIN
        [HttpGet]
        public ActionResult Admin(int? page = 1, int? count = 10)
        {
            return View(ListSages(page.Value, count.Value));
        }
        public ActionResult Create()
        {
            return View("Edit",new Sage().MapToEditSageModel());
        }
        public ActionResult Edit(int id)
        {
            var model = _sagesRepository.Get(id).MapToEditSageModel();
            
            return View(model);
        }

        [Authorize, HttpPost]
        public ActionResult Edit(EditSageModel model)
        {
            if (ModelState.IsValid)
            {
               var sage = model.MapToSage(_sagesRepository.Get(model.Id) ?? new Sage());

                _sagesRepository.Save(sage);

                return RedirectToAction("Admin");
            }

            return View(model);
        }

        private PaginationModel<SageModel> ListSages(int page, int count)
        {
            var total = _sagesRepository.Count();
            var totalPages = total > count
                           ? (total % count) > 0 ? (total / count) + 1 : total / count
                           : 1;

            return new PaginationModel<SageModel>
            {
                Current = page,
                Total = totalPages,
                PageItems = _sagesRepository.List(page, count).MapToListSageModel()
            };
        }
    }
}