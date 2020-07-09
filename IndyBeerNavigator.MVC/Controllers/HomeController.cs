using IndyBeerNavigator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IndyBeerNavigator.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult BindWithViewBag()
        {
            ApplicationDbContext _ctx = new ApplicationDbContext();
            List<SelectListItem> items = new List<SelectListItem>();

            foreach(var brewery in _ctx.Breweries)
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