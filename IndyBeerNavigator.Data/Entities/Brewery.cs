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
        public double Rating { get; set; }
        public string Carryout { get; set; }
        [MaxLength(500, ErrorMessage = "There are too many characters in this field.")]
        public string Review { get; set; }
        public virtual ICollection<Beer> Beers { get; set; } = new List<Beer>();
        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
        public virtual ICollection<BreweryReview> BreweryReviews { get; set; } = new List<BreweryReview();>

    }
}
