using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndyBeerNavigator.Models.SaleModels
{
    public class SaleEdit
    {
        public int SaleId { get; set; }
        public string DayOfTheWeek { get; set; }
        public string SalePrice { get; set; }
    }
}
