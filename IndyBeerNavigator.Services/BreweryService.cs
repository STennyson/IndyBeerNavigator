using IndyBeerNavigator.Data;
using IndyBeerNavigator.Data.Entities;
using IndyBeerNavigator.Models;
using IndyBeerNavigator.Models.BreweryModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndyBeerNavigator.Services
{
    public class BreweryService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        
        // CREATE
        public bool CreateBrewery(BreweryCreate model)
        {
            var entity = new Brewery
            {
                Name = model.Name,
                Address = model.Address,
                Carryout = model.Carryout
            };

            _context.Breweries.Add(entity);
            return _context.SaveChanges() == 1;
        }
        
        // GET ALL
        public List<BreweryListItem> GetAllBreweries()
        {
            var breweryEntities = _context.Breweries.ToList();
            var breweryList = breweryEntities.Select(b => new BreweryListItem
            {
                BreweryId = b.BreweryId,
                Name = b.Name,
                Address = b.Address,
                Carryout = b.Carryout
            }).ToList();
            return breweryList;
        }

        // GET (Details by Id)
        public BreweryDetail GetBreweryById(int breweryId)
        {
            var breweryEntity = _context.Breweries.Find(breweryId);
            if (breweryEntity == null)
                return null;

            var breweryDetail = new BreweryDetail
            {
                BreweryId = breweryEntity.BreweryId,
                Name = breweryEntity.Name,
                Address = breweryEntity.Address,
                Carryout = breweryEntity.Carryout,
                Beers = breweryEntity.Beers,
                Sales = breweryEntity.Sales
            };
            return breweryDetail;
        }
    }
}
