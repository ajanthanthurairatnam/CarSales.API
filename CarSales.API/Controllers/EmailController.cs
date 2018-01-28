using CarSales.API.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarSales.API.Controllers
{
    public class EmailController : ApiController
    {
        // GET: api/Email
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Email/5
        public IHttpActionResult Get(string Email)
        {
            CarSales.API.Models.EF.CarSalesDBEntities db = new CarSales.API.Models.EF.CarSalesDBEntities();
            //Seller seller = db.Sellers.Find(id);
            Seller seller = db.Sellers.Where(e => e.ContactEMail == Email).FirstOrDefault();
            if (seller == null)
            {
                var identityUser = db.AspNetUsers.Where(e => e.UserName == Email).FirstOrDefault();
                if (identityUser != null)
                {
                   
                    return Ok(new { Exist = "User Exist" });
                }
                else
                {
                    return Ok(new { Exist = "Valid" });
                }
            }
            else
            {
                return Ok(new { Exist = "Seller Exist" });

            }
        }

        // POST: api/Email
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Email/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Email/5
        public void Delete(int id)
        {
        }
    }
}
