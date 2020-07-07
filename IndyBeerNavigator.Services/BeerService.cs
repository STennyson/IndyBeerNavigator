using IndyBeerNavigator.Data;
using IndyBeerNavigator.Data.Entities;
using IndyBeerNavigator.Models.BeerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndyBeerNavigator.Services
{
    public class BeerService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // CREATE
        public bool CreateBeer(BeerCreate model)
        {
            Beer entity = new Beer
            {
                Name = model.Name,
                Style = model.Style,
                ABV = model.ABV,
                IBUs = model.IBUs,
                SRM = model.SRM,
                CannedOrBottled = model.CannedOrBottled,
                BreweryId = model.BreweryId,
                Brewery = model.Brewery
            };

            _context.Beers.Add(entity);
            return _context.SaveChanges() == 1;
        }

        // GET ALL
        public List<BeerListItem> GetAllBeers()
        {
            var beerEntities = _context.Beers.ToList();
            var beerList = beerEntities.Select(b => new BeerListItem
            {
                BeerId = b.BeerId,
                Name = b.Name,
                Style = b.Style,
                ABV = b.ABV,
                IBUs = b.IBUs,
                SRM = b.SRM,
                CannedOrBottled = b.CannedOrBottled,
                BreweryId = b.BreweryId,
                Brewery = b.Brewery
            }).ToList();
            return beerList;
        }

        // GET (Details by Id)
        public BeerDetail GetBeerById(int beerId)
        {
            var beerEntity = _context.Beers.Find(beerId);
            if (beerEntity == null)
                return null;

            var beerDetail = new BeerDetail
            {
                BeerId = beerEntity.BeerId,
                Name = beerEntity.Name,
                Style = beerEntity.Style,
                ABV = beerEntity.ABV,
                IBUs = beerEntity.IBUs,
                SRM = beerEntity.SRM,
                CannedOrBottled = beerEntity.CannedOrBottled,
                BreweryId = beerEntity.BreweryId,
                Brewery = beerEntity.Brewery
            };
            return beerDetail;
        }

        // UPDATE
        public bool UpdateBeer(BeerEdit model)
        {
            var beerEntity = _context.Beers.Find(model.BeerId);

            beerEntity.BeerId = model.BeerId;
            beerEntity.Name = model.Name;
            beerEntity.Style = model.Style;
            beerEntity.ABV = model.ABV;
            beerEntity.IBUs = model.IBUs;
            beerEntity.SRM = model.SRM;
            beerEntity.CannedOrBottled = model.CannedOrBottled;
            beerEntity.BreweryId = model.BreweryId;

            return _context.SaveChanges() == 1;
        }

        // DELETE
        public bool DeleteBeer(int beerId)
        {
            var entity = _context.Beers.Find(beerId);

            _context.Beers.Remove(entity);

            return _context.SaveChanges() == 1;
        }
    }
}
