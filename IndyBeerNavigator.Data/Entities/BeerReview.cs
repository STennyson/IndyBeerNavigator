using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndyBeerNavigator.Data.Entities
{
    public class BeerReview
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "There are too many characters in this field.")]
        public string Review { get; set; }
        [Required]
        public double Rating { get; set; }
        [ForeignKey(nameof(Beer))]
        public int BeerId { get; set; }
        public virtual Beer Beer { get; set; }
    }
}
