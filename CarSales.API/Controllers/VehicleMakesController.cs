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
    public class VehicleMakesController : ApiController
    {
        private CarSalesDBEntities db = new CarSalesDBEntities();

        // GET: api/VehicleMakes
        public IQueryable<CarSalesVehicleMake> GetVehicleMakes()
        {           
            IQueryable<CarSalesVehicleMake> CarSalesVehicleMakes=   db.VehicleMakes.Select(p => new CarSalesVehicleMake { ID = p.ID, VehicleMake1 = p.VehicleMake1 });
            return CarSalesVehicleMakes;
        }

        // GET: api/VehicleMakes/5
        [ResponseType(typeof(CarSalesVehicleMake))]
        public IHttpActionResult GetVehicleMake(int id)
        {
            CarSalesVehicleMake vehicleMake = db.VehicleMakes.Where(e=>e.ID==id).Select(p => new CarSalesVehicleMake { ID = p.ID, VehicleMake1 = p.VehicleMake1 }).FirstOrDefault();
            if (vehicleMake == null)
            {
                return NotFound();
            }

            return Ok(vehicleMake);
        }

        // PUT: api/VehicleMakes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicleMake(int id, CarSalesVehicleMake carSalesVehicleMake)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carSalesVehicleMake.ID)
            {
                return BadRequest();
            }

            VehicleMake vehicleMake=new VehicleMake();
            vehicleMake.ID = carSalesVehicleMake.ID;
            vehicleMake.VehicleMake1 = carSalesVehicleMake.VehicleMake1;

            db.Entry(vehicleMake).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleMakeExists(id))
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

        // POST: api/VehicleMakes
        [ResponseType(typeof(CarSalesVehicleMake))]
        public IHttpActionResult PostVehicleMake(CarSalesVehicleMake carSalesVehicleMake)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VehicleMakes.Add(new VehicleMake() { VehicleMake1 = carSalesVehicleMake.VehicleMake1 });
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = carSalesVehicleMake.ID }, carSalesVehicleMake);
        }

        // DELETE: api/VehicleMakes/5
        [ResponseType(typeof(CarSalesVehicleMake))]
        public IHttpActionResult DeleteVehicleMake(int id)
        {
            VehicleMake vehicleMake = db.VehicleMakes.Find(id);
            if (vehicleMake == null)
            {
                return NotFound();
            }

            db.VehicleMakes.Remove(vehicleMake);
            db.SaveChanges();

            CarSalesVehicleMake carSalesVehicle = new CarSalesVehicleMake();
            carSalesVehicle.ID = vehicleMake.ID;
            carSalesVehicle.VehicleMake1 = vehicleMake.VehicleMake1;

            return Ok(vehicleMake);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehicleMakeExists(int id)
        {
            return db.VehicleMakes.Count(e => e.ID == id) > 0;
        }
    }
}