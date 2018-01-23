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
    public class ViewPortsController : ApiController
    {
        private CarSalesDBEntities db = new CarSalesDBEntities();

        // GET: api/ViewPorts
        public IQueryable<CarSalesViewPort> GetViewPorts()
        {
            return db.ViewPorts.Select(e => new CarSalesViewPort() { ID = e.ID,  Description = e.Description });
        }

        // GET: api/ViewPorts/5
        [ResponseType(typeof(CarSalesViewPort))]
        public IHttpActionResult GetViewPort(int id)
        {
            CarSalesViewPort carSalesViewPort = db.ViewPorts.Where(e => e.ID == id).Select(e => new CarSalesViewPort()
            { ID = e.ID, Description = e.Description }).FirstOrDefault();
            if (carSalesViewPort == null)
            {
                return NotFound();
            }

            return Ok(carSalesViewPort);
        }

        // PUT: api/ViewPorts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutViewPort(int id, CarSalesViewPort carSalesViewPort)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carSalesViewPort.ID)
            {
                return BadRequest();
            }
            ViewPort ViewPort = new ViewPort();
            ViewPort.ID = carSalesViewPort.ID;
            ViewPort.Description = carSalesViewPort.Description;

            db.Entry(ViewPort).State = EntityState.Modified;

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
        [ResponseType(typeof(CarSalesViewPort))]
        public IHttpActionResult PostViewPort(ViewPort carSalesViewPort)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ViewPort ViewPort = new ViewPort();
            ViewPort.ID = carSalesViewPort.ID;
            ViewPort.Description = carSalesViewPort.Description;


            db.ViewPorts.Add(ViewPort);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ViewPort.ID }, carSalesViewPort);
        }

        // DELETE: api/ViewPorts/5
        [ResponseType(typeof(CarSalesViewPort))]
        public IHttpActionResult DeleteViewPort(int id)
        {
            ViewPort ViewPort = db.ViewPorts.Find(id);
            if (ViewPort == null)
            {
                return NotFound();
            }

            db.ViewPorts.Remove(ViewPort);
            db.SaveChanges();

            CarSalesViewPort carSalesViewPort = new CarSalesViewPort();
            carSalesViewPort.ID = ViewPort.ID;
            carSalesViewPort.Description = ViewPort.Description;


            return Ok(carSalesViewPort);
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