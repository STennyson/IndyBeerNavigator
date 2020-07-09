using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndyBeerNavigator.Data.Entities
{
    public class BeerReview : Review
    {
        [ForeignKey(nameof(Beer))]
        public int BeerId { get; set; }
        public virtual Beer Beer { get; set; }
    }
}
