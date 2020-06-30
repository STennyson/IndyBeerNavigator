using IndyBeerNavigator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndyBeerNavigator.Models
{
    public class BreweryListItem
    {
        public int BreweryId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Carryout { get; set; }
        public ICollection<Beer> Beers { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
