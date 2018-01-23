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
    public class VehicleSellersController : ApiController
    {
        private CarSalesDBEntities db = new CarSalesDBEntities();

        // GET: api/VehicleSellers
        public IQueryable<CarSalesVehicleSeller> GetVehicleSellers()
        {
            return db.VehicleSellers
                .Select(carSalesVehicleSeller =>
                new CarSalesVehicleSeller()
                { ID = carSalesVehicleSeller.ID, SellerID = carSalesVehicleSeller.SellerID,VehicleID=carSalesVehicleSeller.VehicleID }
                );
        }

        // GET: api/VehicleSellers/5
        [ResponseType(typeof(CarSalesVehicleSeller))]
        public IHttpActionResult GetVehicleSeller(int id)
        {
            CarSalesVehicleSeller VehicleSeller = db.VehicleSellers.Where(e => e.ID == id).
                Select(carSalesVehicleSeller =>
               new CarSalesVehicleSeller()
               {
                   ID = carSalesVehicleSeller.ID,
                   SellerID = carSalesVehicleSeller.SellerID,
                   VehicleID=carSalesVehicleSeller.VehicleID
               }
                )
                .FirstOrDefault();
            if (VehicleSeller == null)
            {
                return NotFound();
            }

            return Ok(VehicleSeller);
        }

        // PUT: api/VehicleSellers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicleSeller(int id, CarSalesVehicleSeller carSalesVehicleSeller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carSalesVehicleSeller.ID)
            {
                return BadRequest();
            }

            VehicleSeller VehicleSeller = new VehicleSeller()
            {
                ID = carSalesVehicleSeller.ID,
                SellerID = carSalesVehicleSeller.SellerID,
                VehicleID = carSalesVehicleSeller.VehicleID
            };


            db.Entry(VehicleSeller).State = EntityState.Modified;

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
        [ResponseType(typeof(CarSalesVehicleSeller))]
        public IHttpActionResult PostVehicleSeller(CarSalesVehicleSeller carSalesVehicleSeller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            VehicleSeller VehicleSeller = new VehicleSeller()
            {
                ID = carSalesVehicleSeller.ID,
                SellerID = carSalesVehicleSeller.SellerID,
                VehicleID = carSalesVehicleSeller.VehicleID
            };


            db.VehicleSellers.Add(VehicleSeller);
            db.SaveChanges();
            carSalesVehicleSeller.ID = VehicleSeller.ID;

            return CreatedAtRoute("DefaultApi", new { id = VehicleSeller.ID }, carSalesVehicleSeller);
        }

        // DELETE: api/VehicleSellers/5
        [ResponseType(typeof(CarSalesVehicleSeller))]
        public IHttpActionResult DeleteVehicleSeller(int id)
        {
            VehicleSeller VehicleSeller = db.VehicleSellers.Find(id);
            if (VehicleSeller == null)
            {
                return NotFound();
            }

           
            db.VehicleSellers.Remove(VehicleSeller);
            db.SaveChanges();

            CarSalesVehicleSeller carSalesVehicleSeller = new CarSalesVehicleSeller()
            {
                ID = VehicleSeller.ID,
                SellerID = VehicleSeller.SellerID,
                VehicleID = VehicleSeller.VehicleID
            };


            return Ok(VehicleSeller);
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