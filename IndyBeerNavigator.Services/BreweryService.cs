﻿using IndyBeerNavigator.Data;
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
            };
            return breweryDetail;
        }

        // GET (Beers by Brewery)
        public List<Beer> GetBeersByBrewery(int breweryId)
        {
            var breweryEntity = _context.Breweries.Find(breweryId);

            List<Beer> brews = new List<Beer>();
            foreach (var beerItem in breweryEntity.Beers)
            {
                brews.Add(beerItem);
            }

            return brews;
        }

        // GET (Sales by Brewery)
        public List<Sale> GetSalesByBrewery(int breweryId)
        {
            var breweryEntity = _context.Breweries.Find(breweryId);

            List<Sale> sales = new List<Sale>();
            foreach (var saleItem in breweryEntity.Sales)
            {
                sales.Add(saleItem);
            }

            return sales;
        }

        // GET (Reviews for a Brewery)
        public List<BreweryReview> GetReviewsForBrewery(int breweryId)
        {
            var entity = _context.Breweries.Find(breweryId);

            List<BreweryReview> revs = new List<BreweryReview>();
            foreach (var rev in entity.BreweryReviews)
            {
                revs.Add(rev);
            }
            return revs;
        }


        // UPDATE
        public bool UpdateBrewery(BreweryEdit model)
        {
            var breweryEntity = _context.Breweries.Find(model.BreweryId);

            breweryEntity.BreweryId = model.BreweryId;
            breweryEntity.Name = model.Name;
            breweryEntity.Address = model.Address;
            breweryEntity.Carryout = model.Carryout;

            return _context.SaveChanges() == 1;
        }

        // DELETE
        public bool DeleteBrewery(int breweryId)
        {
            var entity = _context.Breweries.Find(breweryId);

            _context.Breweries.Remove(entity);

            return _context.SaveChanges() == 1;
        }
    }
}
