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

namespace CarSales.API.Controllers
{
    public class ViewPortSettingsController : ApiController
    {
        private CarSalesDBEntities db = new CarSalesDBEntities();

        // GET: api/ViewPortSettings
        public IQueryable<ViewPortSetting> GetViewPortSettings()
        {
            return db.ViewPortSettings;
        }

        // GET: api/ViewPortSettings/5
        [ResponseType(typeof(ViewPortSetting))]
        public IHttpActionResult GetViewPortSetting(int id)
        {
            ViewPortSetting viewPortSetting = db.ViewPortSettings.Find(id);
            if (viewPortSetting == null)
            {
                return NotFound();
            }

            return Ok(viewPortSetting);
        }

        // PUT: api/ViewPortSettings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutViewPortSetting(int id, ViewPortSetting viewPortSetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != viewPortSetting.ID)
            {
                return BadRequest();
            }

            db.Entry(viewPortSetting).State = EntityState.Modified;

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
        [ResponseType(typeof(ViewPortSetting))]
        public IHttpActionResult PostViewPortSetting(ViewPortSetting viewPortSetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ViewPortSettings.Add(viewPortSetting);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = viewPortSetting.ID }, viewPortSetting);
        }

        // DELETE: api/ViewPortSettings/5
        [ResponseType(typeof(ViewPortSetting))]
        public IHttpActionResult DeleteViewPortSetting(int id)
        {
            ViewPortSetting viewPortSetting = db.ViewPortSettings.Find(id);
            if (viewPortSetting == null)
            {
                return NotFound();
            }

            db.ViewPortSettings.Remove(viewPortSetting);
            db.SaveChanges();

            return Ok(viewPortSetting);
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