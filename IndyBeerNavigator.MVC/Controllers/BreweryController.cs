﻿using IndyBeerNavigator.Models;
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

        // GET
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

        public ActionResult Details(int id)
        {
            var model = _service.GetBreweryById(id);

            return View(model);
        }
    }
}