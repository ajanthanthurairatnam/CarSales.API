using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarSales.API.Models.Interface;

namespace CarSales.API.Models.Classes
{
    public class CarSalesVehicleBody : ICarSalesVehicleBody
    {
        public int ID { get; set; }
        public string BodyDescription { get; set; }
        public string ImageURL { get; set; }
    }
}