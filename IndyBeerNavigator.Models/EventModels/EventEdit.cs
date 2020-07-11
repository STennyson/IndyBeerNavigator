using IndyBeerNavigator.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndyBeerNavigator.Models.EventModels
{
    public class EventEdit
    {
        public int EventId { get; set; }
        [Required]
        [Display(Name = "What kind of event? Music, Comedy, Etc..")]
        public string Type { get; set; }
        [Required]
        [MaxLength(1000, ErrorMessage = "There are too many characters in this field.")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Date")]
        public DateTime EventDate { get; set; }
        [ForeignKey(nameof(Brewery))]
        public int BreweryId { get; set; }
    }
}
