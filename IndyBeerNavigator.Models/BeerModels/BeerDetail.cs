using IndyBeerNavigator.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndyBeerNavigator.Models.BeerModels
{
    public class BeerDetail
    {
        public int BeerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Style { get; set; }
        public bool CannedOrBottled { get; set; }
        public double Rating { get; }
        public Brewery Brewery { get; set; }
    }
}
