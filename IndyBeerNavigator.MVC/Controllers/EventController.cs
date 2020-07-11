using IndyBeerNavigator.Models.EventModels;
using IndyBeerNavigator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IndyBeerNavigator.MVC.Controllers
{
    public class EventController : Controller
    {
        private readonly EventService _service = new EventService();

        private BreweryService CreateBreweryService()
        {
            var service = new BreweryService();
            return service;
        }
        // GET: Event
        public ActionResult Index()
        {
            return View();
        }

        // GET: Event/Create
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
        public ActionResult Create(EventCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (_service.CreateEvent(model))
            {
                TempData["SaveResult"] = "Beer was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Beer could not be created.");
            return View(model);
        }

        // GET: Event/{id}
        public ActionResult Details(int id)
        {
            var model = _service.GetEventById(id);

            return View(model);
        }

        // EDIT: Event/{id}
        public ActionResult Edit(int id)
        {
            var eventEntity = _service.GetEventById(id);
            var model =
                new EventEdit
                {
                    EventId = eventEntity.EventId,
                    Type = eventEntity.Type,
                    Description = eventEntity.Description,
                    EventDate = eventEntity.EventDate,
                    BreweryId = eventEntity.BreweryId
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EventEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.EventId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            if (_service.UpdateEvent(model))
            {
                TempData["SaveResult"] = "Your event was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your event could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var model = _service.GetEventById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveEvent(int id)
        {
            _service.DeleteEvent(id);

            TempData["SaveResult"] = "Your event was deleted.";
            return RedirectToAction("Index");
        }
    }
}