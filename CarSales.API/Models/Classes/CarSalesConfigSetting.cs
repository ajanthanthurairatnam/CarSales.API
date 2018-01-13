using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarSales.API.Models.Interface;

namespace CarSales.API.Models.Classes
{
    public class CarSalesConfigSetting : ICarSalesConfigSetting
    {
        public int ID { get; set; }
        public Nullable<int> VehicleAdvertisementNextRefNo { get; set; }
    }
}