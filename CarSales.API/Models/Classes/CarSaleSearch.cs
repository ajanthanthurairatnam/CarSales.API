using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSales.API.Models.Classes
{
    public class CarSaleSearch
    {
        public string SearchText { get; set; }
        public int PageIndex { get; set; }        
        public int PageNos { get; set; }
        public IEnumerable<CarSalesVehicleAdvertisement> Advertisement { get; set; }
    }
}