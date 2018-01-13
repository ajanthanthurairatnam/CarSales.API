using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarSales.API.Models.Interface;

namespace CarSales.API.Models.Classes
{
    public class CarSalesViewPort : ICarSalesViewPort
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }
}