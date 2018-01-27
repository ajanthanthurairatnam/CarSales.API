using CarSales.API.Models.EF;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.Identity.Owin;


namespace CarSales.API.Models.CustomeFilter
{
    public class SellerActionFilter:ActionFilterAttribute
    {
         public UserManager<IdentityUser> UserManager => HttpContext.Current.GetOwinContext().Get<UserManager<IdentityUser>>();



        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
             CarSalesDBEntities db = new CarSalesDBEntities();
            bool CheckUrCondition = false;
            string userName = filterContext.HttpContext.User.Identity.Name;
            var identityUser = UserManager.FindByName(userName);
            if (identityUser != null)
            {
                
                Seller seller = db.Sellers.Where(e => e.AspNetUsersId == identityUser.Id).FirstOrDefault();
                if (seller != null)
                {
                    CheckUrCondition = true;
                }
            }

          

                if (!CheckUrCondition)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Home",
                    action = "Index"
                }));
            }
        }
    }
}