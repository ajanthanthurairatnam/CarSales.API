using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CarSales.API.Models;
using CarSales.API.Models.Classes;
using CarSales.API.Models.EF;

namespace CarSales.API.Controllers
{
    public class PageSettingsController : ApiController
    {
        private CarSalesDBEntities db = new CarSalesDBEntities();

        // GET: api/ViewPorts
        public CarSalesPageSettings GetPageSettings()
        {
            int VehicleAdvertisementPageCount = 200;
            VehicleAdvertisementPageCount = 1 + ((VehicleAdvertisementPageCount % 10) + VehicleAdvertisementPageCount) / 10;
            return new CarSalesPageSettings() { AdvertisementPageCount = VehicleAdvertisementPageCount };
        }

        // GET: api/PageSettings/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PageSettings
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PageSettings/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PageSettings/5
        public void Delete(int id)
        {
        }
    }
}
