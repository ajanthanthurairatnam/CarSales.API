using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarSales.API.Models.Interface;

namespace CarSales.API.Models.Classes
{
    public class CarSalesVehicleAdvertisement : ICarSalesVehicleAdvertisement
    {
        public int Reference_ID { get; set; }
        public string Title { get; set; }
        public string Reference_No { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> BodyType { get; set; }
        public Nullable<int> EngineCapacity { get; set; }
        public Nullable<decimal> AudoMeter { get; set; }
        public Nullable<int> Fuel { get; set; }
        public string Description { get; set; }
        public string Feature { get; set; }
        public string Spects { get; set; }
        public Nullable<int> Make { get; set; }
        public Nullable<int> Model { get; set; }
        public bool IsFeatured { get; set; }
        public string Transmission { get; set; }
    }
}