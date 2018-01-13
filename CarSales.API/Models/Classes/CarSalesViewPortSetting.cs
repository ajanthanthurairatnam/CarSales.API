using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarSales.API.Models.Interface;

namespace CarSales.API.Models.Classes
{
    public class CarSalesViewPortSetting : ICarSalesViewPortSetting
    {
        public int ID { get; set; }
        public Nullable<int> ViewPortID { get; set; }
        public string SettingCode { get; set; }
        public Nullable<int> PageSize { get; set; }
    }
}