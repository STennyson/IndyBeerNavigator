using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndyBeerNavigator.Data.Entities
{
    public class Brewery
    {
        [Key]
        public int BreweryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string Carryout { get; set; }
        public double Rating { get; }
        public virtual ICollection<Beer> Beers { get; } = new List<Beer>();
        public virtual ICollection<Sale> Sales { get; } = new List<Sale>();
        public virtual ICollection<Event> Events { get; } = new List<Event>();
        public virtual ICollection<BreweryReview> BreweryReviews { get; } = new List<BreweryReview>();

    }
}
