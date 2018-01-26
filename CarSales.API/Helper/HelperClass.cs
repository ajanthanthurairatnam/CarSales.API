using CarSales.API.Models.EF;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSales.API.Helper
{
    public class HelperClass
    {
       
        public static Seller GetSeller(string username)
        {
            CarSalesDBEntities db = new CarSalesDBEntities();
            var identityUser = db.AspNetUsers.Where(e => e.UserName == username).FirstOrDefault();
        
            if (identityUser != null)
            {

                Seller seller = db.Sellers.Where(e => e.AspNetUsersId == identityUser.Id).FirstOrDefault();
                if (seller != null)
                {
                    return seller;
                }
            }






          
           

                return null; 
        }
    }
}