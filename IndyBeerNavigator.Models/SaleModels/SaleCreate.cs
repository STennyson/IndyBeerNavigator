﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndyBeerNavigator.Models.SaleModels
{
    public class SaleCreate
    {
        [Required]
        public string DayOfTheWeek { get; set; }
        [Required]
        public string SalePrice { get; set; }
    }
}
