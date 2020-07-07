using IndyBeerNavigator.Data.Entities;
using IndyBeerNavigator.Models;
using IndyBeerNavigator.Models.BreweryModels;
using IndyBeerNavigator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IndyBeerNavigator.MVC.Controllers
{
    [Authorize]
    public class BreweryController : Controller
    {
        private readonly BreweryService _service = new BreweryService();
        // GET: Brewery
        public ActionResult Index()
        {
            var model = _service.GetAllBreweries();

            return View(model);
        }

        // GET: Brewery/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BreweryCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (_service.CreateBrewery(model))
            {
                TempData["SaveResult"] = "Brewery was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Brewery could not be created.");
            return View(model);
        }
        // GET: Brewery/{id}
        public ActionResult Details(int id)
        {
            var model = _service.GetBreweryById(id);

            return View(model);
        }

        // GET: Brewery/BeerList/{id}
        [HttpGet]
        public ActionResult BeerList(int id)
        {
            var model = _service.GetBeersByBrewery(id);

            return View(model);
        }

        // GET: Brewery/SaleList/{id}
        [HttpGet]
        public ActionResult SaleList(int id)
        {
            var model = _service.GetSalesByBrewery(id);

            return View(model);
        }

        // EDIT: Brewery/{id}
        public ActionResult Edit(int id)
        {
            var detail = _service.GetBreweryById(id);
            var model =
                new BreweryEdit
                {
                    BreweryId = detail.BreweryId,
                    Name = detail.Name,
                    Address = detail.Address,
                    Carryout = detail.Carryout
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BreweryEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.BreweryId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            if (_service.UpdateBrewery(model))
            {
                TempData["SaveResult"] = "Your brewery was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your brewery could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var model = _service.GetBreweryById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveBrewery(int id)
        {
            _service.DeleteBrewery(id);

            TempData["SaveResult"] = "Your brewery was removed.";
            return RedirectToAction("Index");
        }
    }
}