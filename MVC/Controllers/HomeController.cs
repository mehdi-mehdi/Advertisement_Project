using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Advertisement.Common.Dto;
using Advertisement.Common.ServiceContracts;

namespace MVC.Controllers
{
    public class HomeController : ControllerBase
    {
        readonly IPersonService _personService;
        public HomeController(IPersonService personService)
        {
            _personService = personService;
        }
        public ActionResult Create()
        {
            return View(new PersonDto());
        }

        [HttpPost]
        public ActionResult Create(PersonDto model)
        {
            _personService.Insert(model);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var dto = _personService.GetById(id);
            return View(dto);
        }

        [HttpPost]
        public ActionResult Edit(PersonDto model)
        {
            _personService.Update(model);
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var list = _personService.GetAll();
            return View(list);
        }
    }
}