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

        public bool CreateBeerReview(BeerReviewCreate model)
        {
            var entity = new BeerReview()
            {
                OwnerId = _userId,
                Rev = model.Rev,
                Rating = model.Rating,
                CreatedUtc = DateTimeOffset.Now,
                BeerId = model.BeerId,
                Beer = model.Beer
            };

            _context.BeerReviews.Add(entity);
            return _context.SaveChanges() == 1;
        }

        public bool CreateBreweryReview(BreweryReviewCreate model)
        {
            var entity = new BreweryReview()
            {
                OwnerId = _userId,
                Rev = model.Rev,
                Rating = model.Rating,
                CreatedUtc = DateTimeOffset.Now,
                BreweryId = model.BreweryId,
                Brewery = model.Brewery
            };

            _context.BreweryReviews.Add(entity);
            return _context.SaveChanges() == 1;
        }

    }
}
