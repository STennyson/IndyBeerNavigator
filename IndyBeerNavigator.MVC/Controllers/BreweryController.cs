using IndyBeerNavigator.Models;
using IndyBeerNavigator.Models.BreweryModels;
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
        // GET: Brewery
        public ActionResult Index()
        {
            var model = new BreweryListItem[0];
            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BreweryCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}