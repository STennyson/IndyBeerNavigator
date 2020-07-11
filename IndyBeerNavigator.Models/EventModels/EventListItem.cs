using IndyBeerNavigator.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndyBeerNavigator.Models.EventModels
{
    public class EventListItem
    {
        public int EventId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        [ForeignKey(nameof(Brewery))]
        public int BreweryId { get; set; }
        public virtual Brewery Brewery { get; set; }
    }
}
