﻿using IndyBeerNavigator.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndyBeerNavigator.Models.BeerReviewModels
{
    public class BeerReviewCreate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Review")]
        public string Rev { get; set; }
        [Required]
        [Range(0, 10, ErrorMessage = "Rating must be between 0 and 10.")]
        public double Rating { get; set; }
        [ForeignKey(nameof(Beer))]
        public int BeerId { get; set; }
        public virtual Beer Beer { get; set; }
    }
}
