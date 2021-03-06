﻿using IndyBeerNavigator.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndyBeerNavigator.Models
{
    public class BreweryListItem
    {
        public int BreweryId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [Display(Name = "Carryout Options")]
        public string Carryout { get; set; }
    }
}
