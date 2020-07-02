using IndyBeerNavigator.Models.BeerModels;
using IndyBeerNavigator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IndyBeerNavigator.MVC.Controllers
{
    [Authorize]
    public class BeerController : Controller
    {
        private readonly BeerService _service = new BeerService();
        // GET: Beer
        public ActionResult Index()
        {
            var model = _service.GetAllBeers();

            return View(model);
        }

        // GET: Beer/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeerCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (_service.CreateBeer(model))
            {
                TempData["SaveResult"] = "Beer was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Beer could not be created.");
            return View(model);
        }
        // GET: Beer/{id}
        public ActionResult Details(int id)
        {
            var model = _service.GetBeerById(id);

            return View(model);
        }

        // EDIT: Beer/{id}
        public ActionResult Edit(int id)
        {
            var detail = _service.GetBeerById(id);
            var model =
                new BeerEdit
                {
                    Name = detail.Name,
                    Style = detail.Style,
                    CannedOrBottled = detail.CannedOrBottled
                };
            return View(model);
        }
    }
}