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
    public class VehicleSellersController : ApiController
    {
        private CarSalesDBEntities db = new CarSalesDBEntities();

        // GET: api/VehicleSellers
        public IQueryable<VehicleSeller> GetVehicleSellers()
        {
            return db.VehicleSellers;
        }

        // GET: api/VehicleSellers/5
        [ResponseType(typeof(VehicleSeller))]
        public IHttpActionResult GetVehicleSeller(int id)
        {
            VehicleSeller vehicleSeller = db.VehicleSellers.Find(id);
            if (vehicleSeller == null)
            {
                return NotFound();
            }

            return Ok(vehicleSeller);
        }

        // PUT: api/VehicleSellers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicleSeller(int id, VehicleSeller vehicleSeller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicleSeller.ID)
            {
                return BadRequest();
            }

            db.Entry(vehicleSeller).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleSellerExists(id))
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

        // POST: api/VehicleSellers
        [ResponseType(typeof(VehicleSeller))]
        public IHttpActionResult PostVehicleSeller(VehicleSeller vehicleSeller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VehicleSellers.Add(vehicleSeller);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vehicleSeller.ID }, vehicleSeller);
        }

        // DELETE: api/VehicleSellers/5
        [ResponseType(typeof(VehicleSeller))]
        public IHttpActionResult DeleteVehicleSeller(int id)
        {
            VehicleSeller vehicleSeller = db.VehicleSellers.Find(id);
            if (vehicleSeller == null)
            {
                return NotFound();
            }

            db.VehicleSellers.Remove(vehicleSeller);
            db.SaveChanges();

            return Ok(vehicleSeller);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehicleSellerExists(int id)
        {
            return db.VehicleSellers.Count(e => e.ID == id) > 0;
        }
    }
}