using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndyBeerNavigator.Models.BreweryModels
{
    public class BreweryCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Display(Name = "Carryout Options")]
        public string Carryout { get; set; }
        public double Rating { get; }
    }
}
