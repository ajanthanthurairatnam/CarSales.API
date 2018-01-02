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
    public class VehicleAdvertisementsController : ApiController
    {
        private CarSalesDBEntities db = new CarSalesDBEntities();

        // GET: api/VehicleAdvertisements
        public IQueryable<VehicleAdvertisement> GetVehicleAdvertisements()
        {
            return db.VehicleAdvertisements;
        }

        // GET: api/VehicleAdvertisements/5
        [ResponseType(typeof(VehicleAdvertisement))]
        public IHttpActionResult GetVehicleAdvertisement(int id)
        {
            VehicleAdvertisement vehicleAdvertisement = db.VehicleAdvertisements.Find(id);
            if (vehicleAdvertisement == null)
            {
                return NotFound();
            }

            return Ok(vehicleAdvertisement);
        }

        // PUT: api/VehicleAdvertisements/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicleAdvertisement(int id, VehicleAdvertisement vehicleAdvertisement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicleAdvertisement.Reference_ID)
            {
                return BadRequest();
            }

            db.Entry(vehicleAdvertisement).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleAdvertisementExists(id))
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

        // POST: api/VehicleAdvertisements
        [ResponseType(typeof(VehicleAdvertisement))]
        public IHttpActionResult PostVehicleAdvertisement(VehicleAdvertisement vehicleAdvertisement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VehicleAdvertisements.Add(vehicleAdvertisement);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vehicleAdvertisement.Reference_ID }, vehicleAdvertisement);
        }

        // DELETE: api/VehicleAdvertisements/5
        [ResponseType(typeof(VehicleAdvertisement))]
        public IHttpActionResult DeleteVehicleAdvertisement(int id)
        {
            VehicleAdvertisement vehicleAdvertisement = db.VehicleAdvertisements.Find(id);
            if (vehicleAdvertisement == null)
            {
                return NotFound();
            }

            db.VehicleAdvertisements.Remove(vehicleAdvertisement);
            db.SaveChanges();

            return Ok(vehicleAdvertisement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehicleAdvertisementExists(int id)
        {
            return db.VehicleAdvertisements.Count(e => e.Reference_ID == id) > 0;
        }
    }
}