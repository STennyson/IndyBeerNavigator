using IndyBeerNavigator.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndyBeerNavigator.Models.SaleModels
{
    public class SaleEdit
    {
        public int SaleId { get; set; }
        public string DayOfTheWeek { get; set; }
        public string SalePrice { get; set; }
        [ForeignKey(nameof(Brewery))]
        public int BreweryId { get; set; }
    }
}
