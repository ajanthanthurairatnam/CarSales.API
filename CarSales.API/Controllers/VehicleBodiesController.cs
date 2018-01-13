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

namespace CarSales.API.Controllers
{
    public class VehicleBodiesController : ApiController
    {
        private CarSalesDBEntities db = new CarSalesDBEntities();

        // GET: api/VehicleBodies
        public IQueryable<CarSalesVehicleBody> GetVehicleBodies()
        {
            return db.VehicleBodies
                .Select(e => 
                new CarSalesVehicleBody()
                    { ID = e.ID, BodyDescription = e.BodyDescription,ImageURL=e.ImageURL }
                );

        }

        // GET: api/VehicleBodies/5
        [ResponseType(typeof(CarSalesVehicleBody))]
        public IHttpActionResult GetVehicleBody(int id)
        {
            CarSalesVehicleBody carSalesVehicleBody = db.VehicleBodies.Where(e=>e.ID==id)
                .Select(e =>
                new CarSalesVehicleBody()
                {
                    ID = e.ID, BodyDescription = e.BodyDescription, ImageURL = e.ImageURL }
                )
                .FirstOrDefault();

            if (carSalesVehicleBody == null)
            {
                return NotFound();
            }

            return Ok(carSalesVehicleBody);
        }

        // PUT: api/VehicleBodies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicleBody(int id, CarSalesVehicleBody carSalesVehicleBody)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carSalesVehicleBody.ID)
            {
                return BadRequest();
            }

            VehicleBody vehicleBody=  new VehicleBody()
            {
                ID = carSalesVehicleBody.ID,
                BodyDescription = carSalesVehicleBody.BodyDescription,
                ImageURL = carSalesVehicleBody.ImageURL
            };
                
            db.Entry(vehicleBody).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleBodyExists(id))
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

        // POST: api/VehicleBodies
        [ResponseType(typeof(CarSalesVehicleBody))]
        public IHttpActionResult PostVehicleBody(CarSalesVehicleBody carSalesVehicleBody)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            VehicleBody vehicleBody = new VehicleBody()
            {
                ID = carSalesVehicleBody.ID,
                BodyDescription = carSalesVehicleBody.BodyDescription,
                ImageURL = carSalesVehicleBody.ImageURL
            };
            carSalesVehicleBody.ID = vehicleBody.ID;

            db.VehicleBodies.Add(vehicleBody);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = carSalesVehicleBody.ID }, carSalesVehicleBody);
        }

        // DELETE: api/VehicleBodies/5
        [ResponseType(typeof(CarSalesVehicleBody))]
        public IHttpActionResult DeleteVehicleBody(int id)
        {
            VehicleBody vehicleBody = db.VehicleBodies.Find(id);
            if (vehicleBody == null)
            {
                return NotFound();
            }

            
                

            db.VehicleBodies.Remove(vehicleBody);
            db.SaveChanges();

            CarSalesVehicleBody carSalesVehicleBody = new CarSalesVehicleBody()
            {
                ID = vehicleBody.ID,
                BodyDescription = vehicleBody.BodyDescription,
                ImageURL = vehicleBody.ImageURL
            };

            return Ok(carSalesVehicleBody);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehicleBodyExists(int id)
        {
            return db.VehicleBodies.Count(e => e.ID == id) > 0;
        }
    }
}