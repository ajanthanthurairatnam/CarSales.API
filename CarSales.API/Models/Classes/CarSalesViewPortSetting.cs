using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 

namespace CarSales.API.Models.Classes
{
    public class CarSalesViewPortSetting  
    {
        public int ID { get; set; }
        public Nullable<int> ViewPortID { get; set; }
        public string SettingCode { get; set; }
        public Nullable<int> PageSize { get; set; }
    }
}