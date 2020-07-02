using IndyBeerNavigator.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndyBeerNavigator.Models.BreweryModels
{
    public class BreweryDetail
    {
        public int BreweryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Display(Name = "Carryout Options")]
        public string Carryout { get; set; }
        public ICollection<Beer> Beers { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
