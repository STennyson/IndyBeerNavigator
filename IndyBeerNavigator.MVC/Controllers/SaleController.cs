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
        // GET: Sale
        public ActionResult Index()
        {
            var model = _service.GetAllSales();
            return View(model);
        }

        // GET: Sale/Create
        public ActionResult Create()
        {
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
    }
}