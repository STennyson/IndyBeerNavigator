using IndyBeerNavigator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndyBeerNavigator.Models.SaleModels
{
    public class SaleListItem
    {
        public int SaleId { get; set; }
        public string DayOfTheWeek { get; set; }
        public string SalePrice { get; set; }
        public int BreweryId { get; set; }
        public virtual Brewery Brewery { get; set; }
    }
}
