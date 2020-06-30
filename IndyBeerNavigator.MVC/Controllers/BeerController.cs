using IndyBeerNavigator.Models.BeerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IndyBeerNavigator.MVC.Controllers
{
    public class BeerController : Controller
    {
        // GET: Beer
        public ActionResult Index()
        {
            var model = new BeerListItem[0];
            return View(model);
        }
    }
}