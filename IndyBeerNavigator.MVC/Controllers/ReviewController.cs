using IndyBeerNavigator.Models.BreweryReviewModels;
using IndyBeerNavigator.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IndyBeerNavigator.MVC.Controllers
{
    public class ReviewController : Controller
    {

        // GET: Review
        /*public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReviewService(userId);
            var model = service.GetReviews();

            return View(model);
        }*/

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BreweryReviewCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}