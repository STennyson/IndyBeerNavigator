using IndyBeerNavigator.Data;
using IndyBeerNavigator.Models.SaleModels;
using IndyBeerNavigator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IndyBeerNavigator.MVC.Controllers
{
    [Authorize]
    public class SaleController : Controller
    {
        private readonly SaleService _service = new SaleService();

        private BreweryService CreateBreweryService()
        {
            var service = new BreweryService();
            return service;
        }
        // GET: Sale
        public ActionResult Index()
        {
            var model = _service.GetAllSales();
            return View(model);
        }

        // GET: Sale/Create
        public ActionResult Create()
        {
            var brewServ = CreateBreweryService();
            var getBrewery = brewServ.GetAllBreweries();
            ViewBag.Breweries = getBrewery.ToList();
            return View();
        }

        // GET
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SaleCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (_service.CreateSale(model))
            {
                TempData["SaveResult"] = "Sale was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Sale could not be created.");
            return View(model);
        }
        // GET: Sale/{id}
        public ActionResult Details(int id)
        {
            var model = _service.GetSaleById(id);

            return View(model);
        }

        // EDIT: Sale/{id}
        public ActionResult Edit(int id)
        {
            var detail = _service.GetSaleById(id);
            var model =
                new SaleEdit
                {
                    SaleId = detail.SaleId,
                    DayOfTheWeek = detail.DayOfTheWeek,
                    SalePrice = detail.SalePrice,
                    BreweryId = detail.BreweryId
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SaleEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.SaleId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            if (_service.UpdateSale(model))
            {
                TempData["SaveResult"] = "Your sale was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your sale could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var model = _service.GetSaleById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveSale(int id)
        {
            _service.DeleteSale(id);

            TempData["SaveResult"] = "Your sale was removed.";
            return RedirectToAction("Index");
        }

        public ActionResult GetBreweryNames()
        {
            ApplicationDbContext _ctx = new ApplicationDbContext();
            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var brewery in _ctx.Breweries)
            {
                items.Add(new SelectListItem
                {
                    Text = brewery.Name,
                    Value = brewery.BreweryId.ToString()
                });
            }

            ViewBag.CategoryType = items;

            return View();
        }
    }
}