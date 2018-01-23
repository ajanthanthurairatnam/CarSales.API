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
    public class VehicleFuelsController : ApiController
    {
        private CarSalesDBEntities db = new CarSalesDBEntities();

        // GET: api/VehicleFuels
        public IQueryable<CarSalesVehicleFuel> GetVehicleFuels()
        {
            return db.VehicleFuels
                .Select(carSalesVehicleFuel =>
                new CarSalesVehicleFuel()
                { ID = carSalesVehicleFuel.ID, FuelType = carSalesVehicleFuel.FuelType }
                );
        }

        // GET: api/VehicleFuels/5
        [ResponseType(typeof(CarSalesVehicleFuel))]
        public IHttpActionResult GetVehicleFuel(int id)
        {
            CarSalesVehicleFuel vehicleFuel = db.VehicleFuels.Where(e=> e.ID==id).
                Select(carSalesVehicleFuel =>
               new CarSalesVehicleFuel()
               {
                   ID = carSalesVehicleFuel.ID, FuelType = carSalesVehicleFuel.FuelType }
                )
                .FirstOrDefault();
            if (vehicleFuel == null)
            {
                return NotFound();
            }

            return Ok(vehicleFuel);
        }

        // PUT: api/VehicleFuels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicleFuel(int id, CarSalesVehicleFuel carSalesVehicleFuel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carSalesVehicleFuel.ID)
            {
                return BadRequest();
            }

            VehicleFuel vehicleFuel = new VehicleFuel()
            {
                ID = carSalesVehicleFuel.ID,
                FuelType = carSalesVehicleFuel.FuelType
            };
                

            db.Entry(vehicleFuel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleFuelExists(id))
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

        // POST: api/VehicleFuels
        [ResponseType(typeof(CarSalesVehicleFuel))]
        public IHttpActionResult PostVehicleFuel(CarSalesVehicleFuel carSalesVehicleFuel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            VehicleFuel vehicleFuel = new VehicleFuel()
            {
                ID = carSalesVehicleFuel.ID,
                FuelType = carSalesVehicleFuel.FuelType
            };


            db.VehicleFuels.Add(vehicleFuel);
            db.SaveChanges();
            carSalesVehicleFuel.ID = vehicleFuel.ID;

            return CreatedAtRoute("DefaultApi", new { id = vehicleFuel.ID }, carSalesVehicleFuel);
        }

        // DELETE: api/VehicleFuels/5
        [ResponseType(typeof(CarSalesVehicleFuel))]
        public IHttpActionResult DeleteVehicleFuel(int id)
        {
            VehicleFuel vehicleFuel = db.VehicleFuels.Find(id);
            if (vehicleFuel == null)
            {
                return NotFound();
            }

            CarSalesVehicleFuel carSalesVehicleFuel = new CarSalesVehicleFuel()
            {
                ID = vehicleFuel.ID,
                FuelType = vehicleFuel.FuelType
            };

            db.VehicleFuels.Remove(vehicleFuel);
            db.SaveChanges();

            return Ok(vehicleFuel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehicleFuelExists(int id)
        {
            return db.VehicleFuels.Count(e => e.ID == id) > 0;
        }
    }
}