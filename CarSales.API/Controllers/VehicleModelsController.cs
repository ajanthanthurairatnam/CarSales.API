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
    public class VehicleModelsController : ApiController
    {
        private CarSalesDBEntities db = new CarSalesDBEntities();

        // GET: api/VehicleModels
        public IQueryable<VehicleModel> GetVehicleModels()
        {
            return db.VehicleModels;
        }

        // GET: api/VehicleModels/5
        [ResponseType(typeof(VehicleModel))]
        public IHttpActionResult GetVehicleModel(int id)
        {
            VehicleModel vehicleModel = db.VehicleModels.Find(id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            return Ok(vehicleModel);
        }

        // PUT: api/VehicleModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicleModel(int id, VehicleModel vehicleModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicleModel.ID)
            {
                return BadRequest();
            }

            db.Entry(vehicleModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleModelExists(id))
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

        // POST: api/VehicleModels
        [ResponseType(typeof(VehicleModel))]
        public IHttpActionResult PostVehicleModel(VehicleModel vehicleModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VehicleModels.Add(vehicleModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vehicleModel.ID }, vehicleModel);
        }

        // DELETE: api/VehicleModels/5
        [ResponseType(typeof(VehicleModel))]
        public IHttpActionResult DeleteVehicleModel(int id)
        {
            VehicleModel vehicleModel = db.VehicleModels.Find(id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            db.VehicleModels.Remove(vehicleModel);
            db.SaveChanges();

            return Ok(vehicleModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehicleModelExists(int id)
        {
            return db.VehicleModels.Count(e => e.ID == id) > 0;
        }
    }
}