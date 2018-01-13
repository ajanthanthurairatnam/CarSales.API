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
    public class VehicleModelsController : ApiController
    {
        private CarSalesDBEntities db = new CarSalesDBEntities();

        // GET: api/VehicleModels
        public IQueryable<CarSalesVehicleModel> GetVehicleModels()
        {
            return db.VehicleModels
                .Select(carSalesVehicleModel =>
                new CarSalesVehicleModel()
                { ID = carSalesVehicleModel.ID, VehicleModel1 = carSalesVehicleModel.VehicleModel1,VehicleMakeID= carSalesVehicleModel.VehicleMakeID }
                );
        }

        // GET: api/VehicleModels/5
        [ResponseType(typeof(CarSalesVehicleModel))]
        public IHttpActionResult GetVehicleModel(int id)
        {
            CarSalesVehicleModel vehicleModel = db.VehicleModels.Where(e => e.ID == id).
                Select(carSalesVehicleModel =>
               new CarSalesVehicleModel()
               {
                   ID = carSalesVehicleModel.ID,
                   VehicleMakeID = carSalesVehicleModel.VehicleMakeID,
                   VehicleModel1= carSalesVehicleModel.VehicleModel1,
               }
                )
                .FirstOrDefault();
            if (vehicleModel == null)
            {
                return NotFound();
            }

            return Ok(vehicleModel);
        }

        // PUT: api/VehicleModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicleModel(int id, CarSalesVehicleModel carSalesVehicleModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carSalesVehicleModel.ID)
            {
                return BadRequest();
            }

            VehicleModel vehicleModel = new VehicleModel()
            {
                ID = carSalesVehicleModel.ID,
                VehicleMakeID = carSalesVehicleModel.VehicleMakeID,
                VehicleModel1= carSalesVehicleModel.VehicleModel1
            };


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
        [ResponseType(typeof(CarSalesVehicleModel))]
        public IHttpActionResult PostVehicleModel(CarSalesVehicleModel carSalesVehicleModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            VehicleModel vehicleModel = new VehicleModel()
            {
                ID = carSalesVehicleModel.ID,
                VehicleMakeID = carSalesVehicleModel.VehicleMakeID,
                VehicleModel1 = carSalesVehicleModel.VehicleModel1
            };


            db.VehicleModels.Add(vehicleModel);
            db.SaveChanges();
            carSalesVehicleModel.ID = vehicleModel.ID;

            return CreatedAtRoute("DefaultApi", new { id = vehicleModel.ID }, carSalesVehicleModel);
        }

        // DELETE: api/VehicleModels/5
        [ResponseType(typeof(CarSalesVehicleModel))]
        public IHttpActionResult DeleteVehicleModel(int id)
        {
            VehicleModel vehicleModel = db.VehicleModels.Find(id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            CarSalesVehicleModel carSalesVehicleModel = new CarSalesVehicleModel()
            {
                ID = vehicleModel.ID,
                VehicleMakeID = vehicleModel.VehicleMakeID,
                VehicleModel1 = vehicleModel.VehicleModel1
            };

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