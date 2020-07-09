using IndyBeerNavigator.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndyBeerNavigator.Models.BeerReviewModels
{
    public class BeerReviewListItem
    {
        
        public int Id { get; set; }
        public Guid OwnerId { get; set; }
        public string Rev { get; set; }
        public double Rating { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [ForeignKey(nameof(Beer))]
        public int BeerId { get; set; }
        public virtual Beer Beer { get; set; }
    }
}
