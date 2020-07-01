using IndyBeerNavigator.Data;
using IndyBeerNavigator.Data.Entities;
using IndyBeerNavigator.Models.SaleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndyBeerNavigator.Services
{
    public class SaleService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // CREATE
        public bool CreateSale(SaleCreate model)
        {
            Sale entity = new Sale
            {
                DayOfTheWeek = model.DayOfTheWeek,
                SalePrice = model.SalePrice,
                BreweryId = model.BreweryId
            };

            _context.Sales.Add(entity);
            return _context.SaveChanges() == 1;
        }

        // GET ALL
        public List<SaleDetail> GetAllSales()
        {
            var saleEntities = _context.Sales.ToList();
            var saleList = saleEntities.Select(b => new SaleDetail
            {
                SaleId = b.SaleId,
                DayOfTheWeek = b.DayOfTheWeek,
                SalePrice = b.SalePrice,
                BreweryId = b.BreweryId,
                Brewery = b.Brewery
            }).ToList();
            return saleList;
        }

        // GET (Details by Id)
        public SaleDetail GetSaleById(int saleId)
        {
            var saleEntity = _context.Sales.Find(saleId);
            if (saleEntity == null)
                return null;
            var saleDetail = new SaleDetail
            {
                SaleId = saleEntity.SaleId,
                DayOfTheWeek = saleEntity.DayOfTheWeek,
                SalePrice = saleEntity.SalePrice,
                BreweryId = saleEntity.BreweryId,
                Brewery = saleEntity.Brewery
            };
            return saleDetail;
        }
    }
}
