using IndyBeerNavigator.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndyBeerNavigator.Models.SaleModels
{
    public class SaleDetail
    {
        public int SaleId { get; set; }
        [Required]
        public string DayOfTheWeek { get; set; }
        [Required]
        public string SalePrice { get; set; }
        [ForeignKey(nameof(Brewery))]
        public int BreweryId { get; set; }
        public virtual Brewery Brewery { get; set; }
    }
}
