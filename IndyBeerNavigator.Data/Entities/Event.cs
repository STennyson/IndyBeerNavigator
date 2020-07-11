using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndyBeerNavigator.Data.Entities
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        [Required]
        [Display (Name = "What kind of event? Music, Comedy, Etc..")]
        public string Type { get; set; }
        [Required]
        [MaxLength(1000, ErrorMessage = "There are too many characters in this field.")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Date")]
        public DateTime EventDate { get; set; }
        [ForeignKey(nameof(Brewery))]
        public int BreweryId { get; set; }
        public virtual Brewery Brewery { get; set; }
    }
}
