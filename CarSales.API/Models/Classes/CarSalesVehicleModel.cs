using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 

namespace CarSales.API.Models.Classes
{
    public class CarSalesVehicleModel  
    {
        public int ID { get; set; }
        public string VehicleModel1 { get; set; }
        public Nullable<int> VehicleMakeID { get; set; }
    }
}