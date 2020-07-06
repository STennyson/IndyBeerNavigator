using IndyBeerNavigator.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndyBeerNavigator.Models.BeerModels
{
    public class BeerListItem
    {
        public int BeerId { get; set; }
        public string Name { get; set; }
        public string Style { get; set; }
        public bool CannedOrBottled { get; set; }
        [ForeignKey(nameof(Brewery))]
        public int BreweryId { get; set; }
        public virtual Brewery Brewery { get; set; }
    }
}
