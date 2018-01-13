using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarSales.API.Models.Interface;

namespace CarSales.API.Models.Classes
{
    public class CarSalesVehicleSeller : ICarSalesVehicleSeller
    {
        public int ID { get; set; }
        public Nullable<int> VehicleID { get; set; }
        public int SellerID { get; set; }
    }
}