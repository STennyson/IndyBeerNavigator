using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndyBeerNavigator.Models.BeerModels
{
    public class BeerEdit
    {
        public int BeerId { get; set; }
        public string Name { get; set; }
        public string Style { get; set; }
        public bool CannedOrBottled { get; set; }
    }
}
