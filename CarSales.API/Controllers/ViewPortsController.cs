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
    public class ViewPortsController : ApiController
    {
        private CarSalesDBEntities db = new CarSalesDBEntities();

        // GET: api/ViewPorts
        public IQueryable<ViewPort> GetViewPorts()
        {
            return db.ViewPorts;
        }

        // GET: api/ViewPorts/5
        [ResponseType(typeof(ViewPort))]
        public IHttpActionResult GetViewPort(int id)
        {
            ViewPort viewPort = db.ViewPorts.Find(id);
            if (viewPort == null)
            {
                return NotFound();
            }

            return Ok(viewPort);
        }

        // PUT: api/ViewPorts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutViewPort(int id, ViewPort viewPort)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != viewPort.ID)
            {
                return BadRequest();
            }

            db.Entry(viewPort).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViewPortExists(id))
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

        // POST: api/ViewPorts
        [ResponseType(typeof(ViewPort))]
        public IHttpActionResult PostViewPort(ViewPort viewPort)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ViewPorts.Add(viewPort);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ViewPortExists(viewPort.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = viewPort.ID }, viewPort);
        }

        // DELETE: api/ViewPorts/5
        [ResponseType(typeof(ViewPort))]
        public IHttpActionResult DeleteViewPort(int id)
        {
            ViewPort viewPort = db.ViewPorts.Find(id);
            if (viewPort == null)
            {
                return NotFound();
            }

            db.ViewPorts.Remove(viewPort);
            db.SaveChanges();

            return Ok(viewPort);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ViewPortExists(int id)
        {
            return db.ViewPorts.Count(e => e.ID == id) > 0;
        }
    }
}