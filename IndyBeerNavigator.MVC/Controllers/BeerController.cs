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

        // GET: Beer/Review/{id}
        [HttpGet]
        public ActionResult Reviews(int id)
        {
            var model = _service.GetReviewsForBeer(id);

            return View(model);
        }

        // EDIT: Beer/{id}
        public ActionResult Edit(int id)
        {
            var detail = _service.GetBeerById(id);
            var model =
                new BeerEdit
                {
                    BeerId = detail.BeerId,
                    Name = detail.Name,
                    Style = detail.Style,
                    ABV = detail.ABV,
                    IBUs = detail.IBUs,
                    SRM = detail.SRM,
                    CannedOrBottled = detail.CannedOrBottled,
                    BreweryId = detail.BreweryId
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BeerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.BeerId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            if (_service.UpdateBeer(model))
            {
                TempData["SaveResult"] = "Your beer was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your beer could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var model = _service.GetBeerById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveBeer(int id)
        {
            _service.DeleteBeer(id);

            TempData["SaveResult"] = "Your beer was deleted.";
            return RedirectToAction("Index");
        }
    }
}