using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CarSales.API.Models;
 
using CarSales.API.Models.Classes;
using CarSales.API.Models.EF;

namespace CarSales.API.Controllers
{
    public class ConfigSettingsController : ApiController
    {
        private CarSalesDBEntities db = new CarSalesDBEntities();

        // GET: api/ConfigSettings
        public IQueryable<CarSalesConfigSetting> GetConfigSettings()
        {
            return db.ConfigSettings.Select(e=>new CarSalesConfigSetting() { ID=e.ID,VehicleAdvertisementNextRefNo=e.VehicleAdvertisementNextRefNo});
        }

        // GET: api/ConfigSettings/5
        [ResponseType(typeof(CarSalesConfigSetting))]
        public IHttpActionResult GetConfigSetting(int id)
        {
            CarSalesConfigSetting carSalesConfigSetting = db.ConfigSettings.Where(e=>e.ID==id).Select(e => new CarSalesConfigSetting()
                                { ID = e.ID, VehicleAdvertisementNextRefNo = e.VehicleAdvertisementNextRefNo }).FirstOrDefault();
            if (carSalesConfigSetting == null)
            {
                return NotFound();
            }

            return Ok(carSalesConfigSetting);
        }

        // PUT: api/ConfigSettings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConfigSetting(int id, CarSalesConfigSetting carSalesConfigSetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carSalesConfigSetting.ID)
            {
                return BadRequest();
            }
            ConfigSetting configSetting = new ConfigSetting();
            configSetting.ID = carSalesConfigSetting.ID;
            configSetting.VehicleAdvertisementNextRefNo = carSalesConfigSetting.VehicleAdvertisementNextRefNo;

            db.Entry(configSetting).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfigSettingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ConfigSettings
        [ResponseType(typeof(CarSalesConfigSetting))]
        public IHttpActionResult PostConfigSetting(ConfigSetting carSalesConfigSetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ConfigSetting configSetting = new ConfigSetting();
            configSetting.ID = carSalesConfigSetting.ID;
            configSetting.VehicleAdvertisementNextRefNo = carSalesConfigSetting.VehicleAdvertisementNextRefNo;


            db.ConfigSettings.Add(configSetting);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = configSetting.ID }, carSalesConfigSetting);
        }

        // DELETE: api/ConfigSettings/5
        [ResponseType(typeof(CarSalesConfigSetting))]
        public IHttpActionResult DeleteConfigSetting(int id)
        {
            ConfigSetting configSetting = db.ConfigSettings.Find(id);
            if (configSetting == null)
            {
                return NotFound();
            }

            db.ConfigSettings.Remove(configSetting);
            db.SaveChanges();

            CarSalesConfigSetting carSalesConfigSetting = new CarSalesConfigSetting();
            carSalesConfigSetting.ID = configSetting.ID;
            carSalesConfigSetting.VehicleAdvertisementNextRefNo = configSetting.VehicleAdvertisementNextRefNo;


            return Ok(carSalesConfigSetting);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConfigSettingExists(int id)
        {
            return db.ConfigSettings.Count(e => e.ID == id) > 0;
        }
    }
}