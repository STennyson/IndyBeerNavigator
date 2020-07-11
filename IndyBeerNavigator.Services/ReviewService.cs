using IndyBeerNavigator.Data;
using IndyBeerNavigator.Data.Entities;
using IndyBeerNavigator.Models.BeerReviewModels;
using IndyBeerNavigator.Models.BreweryReviewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndyBeerNavigator.Services
{
    public class ReviewService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        private readonly Guid _userId;

        public ReviewService(Guid userId)
        {
            _userId = userId;
        }


        //Create beer review
        public bool CreateBeerReview(BeerReviewCreate model, int beerId)
        {
            var beerEntity = _context.Beers.Find(beerId);

            var entity = new BeerReview()
            {
                OwnerId = _userId,
                Rev = model.Rev,
                Rating = model.Rating,
                CreatedUtc = DateTimeOffset.Now,
                BeerId = beerEntity.BeerId,
                Beer = model.Beer
            };

            _context.BeerReviews.Add(entity);
            return _context.SaveChanges() == 1;
        }
        //Create brewery review
        public bool CreateBreweryReview(BreweryReviewCreate model, int breweryId)
        {
            var breweryEntity = _context.Breweries.Find(breweryId);

            var entity = new BreweryReview()
            {
                OwnerId = _userId,
                Rev = model.Rev,
                Rating = model.Rating,
                CreatedUtc = DateTimeOffset.Now,
                BreweryId = breweryEntity.BreweryId,
                Brewery = model.Brewery
            };

            _context.BreweryReviews.Add(entity);
            return _context.SaveChanges() == 1;
        }

    }
}
