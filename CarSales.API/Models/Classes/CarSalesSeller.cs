﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 

namespace CarSales.API.Models.Classes
{
    public class CarSalesSeller  
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public string ContactMobile { get; set; }
        public string ContactEMail { get; set; }
        public string PickupAddress { get; set; }
        public string PostCode { get; set; }
    }
}