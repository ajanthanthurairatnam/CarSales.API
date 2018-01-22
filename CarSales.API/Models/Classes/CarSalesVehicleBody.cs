using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 

namespace CarSales.API.Models.Classes
{
    public class CarSalesVehicleBody 
    {
        public int ID { get; set; }
        public string BodyDescription { get; set; }
        public string ImageURL { get; set; }
    }
}