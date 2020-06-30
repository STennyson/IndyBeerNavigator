using IndyBeerNavigator.Models.SaleModels;
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
        // GET: Sale
        public ActionResult Index()
        {
            var model = new SaleListItem[0];
            return View(model);
        }
    }
}