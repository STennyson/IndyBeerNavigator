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
        [Display(Name = "Review")]
        public string Rev { get; set; }
        public double Rating { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
