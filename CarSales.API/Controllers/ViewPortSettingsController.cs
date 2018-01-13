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
using CarSales.API.Models.Interface;
using CarSales.API.Models.Classes;

namespace CarSales.API.Controllers
{
    public class ViewPortSettingsController : ApiController
    {
        private CarSalesDBEntities db = new CarSalesDBEntities();

        // GET: api/ViewPortSettings
        public IQueryable<CarSalesViewPortSetting> GetViewPortSettings()
        {
            return db.ViewPortSettings.Select(e => new CarSalesViewPortSetting() { ID = e.ID, PageSize = e.PageSize,SettingCode=e.SettingCode,ViewPortID=e.ViewPortID  });
        }

        // GET: api/ViewPortSettings/5
        [ResponseType(typeof(CarSalesViewPortSetting))]
        public IHttpActionResult GetViewPortSetting(int id)
        {
            CarSalesViewPortSetting carSalesViewPortSetting = db.ViewPortSettings.Where(e => e.ID == id).Select(e => new CarSalesViewPortSetting()
            { ID = e.ID, PageSize = e.PageSize, SettingCode = e.SettingCode, ViewPortID = e.ViewPortID }).FirstOrDefault();
            if (carSalesViewPortSetting == null)
            {
                return NotFound();
            }

            return Ok(carSalesViewPortSetting);
        }

        // PUT: api/ViewPortSettings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutViewPortSetting(int id, CarSalesViewPortSetting carSalesViewPortSetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carSalesViewPortSetting.ID)
            {
                return BadRequest();
            }
            ViewPortSetting ViewPortSetting = new ViewPortSetting();
            ViewPortSetting.ID = carSalesViewPortSetting.ID;
            ViewPortSetting.PageSize = carSalesViewPortSetting.PageSize;
            ViewPortSetting.SettingCode = carSalesViewPortSetting.SettingCode;
            ViewPortSetting.ViewPortID = carSalesViewPortSetting.ViewPortID;

            db.Entry(ViewPortSetting).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViewPortSettingExists(id))
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

        // POST: api/ViewPortSettings
        [ResponseType(typeof(CarSalesViewPortSetting))]
        public IHttpActionResult PostViewPortSetting(ViewPortSetting carSalesViewPortSetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ViewPortSetting ViewPortSetting = new ViewPortSetting();
            ViewPortSetting.ID = carSalesViewPortSetting.ID;
            ViewPortSetting.PageSize = carSalesViewPortSetting.PageSize;
            ViewPortSetting.SettingCode = carSalesViewPortSetting.SettingCode;
            ViewPortSetting.ViewPortID = carSalesViewPortSetting.ViewPortID;

            db.ViewPortSettings.Add(ViewPortSetting);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ViewPortSetting.ID }, carSalesViewPortSetting);
        }

        // DELETE: api/ViewPortSettings/5
        [ResponseType(typeof(CarSalesViewPortSetting))]
        public IHttpActionResult DeleteViewPortSetting(int id)
        {
            ViewPortSetting ViewPortSetting = db.ViewPortSettings.Find(id);
            if (ViewPortSetting == null)
            {
                return NotFound();
            }

            db.ViewPortSettings.Remove(ViewPortSetting);
            db.SaveChanges();

            CarSalesViewPortSetting carSalesViewPortSetting = new CarSalesViewPortSetting();
            carSalesViewPortSetting.ID = ViewPortSetting.ID;
            carSalesViewPortSetting.PageSize = ViewPortSetting.PageSize;
            carSalesViewPortSetting.SettingCode = ViewPortSetting.SettingCode;
            carSalesViewPortSetting.ViewPortID = ViewPortSetting.ViewPortID;

            return Ok(carSalesViewPortSetting);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ViewPortSettingExists(int id)
        {
            return db.ViewPortSettings.Count(e => e.ID == id) > 0;
        }
    }
}