using IndyBeerNavigator.Models;
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
    }
}