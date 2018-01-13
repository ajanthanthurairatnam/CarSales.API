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
    public class VehicleAdvertisementsController : ApiController
    {
        private CarSalesDBEntities db = new CarSalesDBEntities();

        // GET: api/VehicleAdvertisements
        public IQueryable<CarSalesVehicleAdvertisement> GetVehicleAdvertisements(string SearchText="", int id=0, int PageSize=10, int PageNo=1)
        {
            return db.VehicleAdvertisements.Where(e => SearchText == "" ? true : e.Title.Contains(SearchText))
                .Select(f => new CarSalesVehicleAdvertisement()
                {
                    AudoMeter = f.AudoMeter,
                    BodyType = f.BodyType,
                    Description = f.Description,
                    EngineCapacity = f.EngineCapacity,
                    Feature = f.Feature,
                    Fuel=f.Fuel,
                    IsFeatured=f.IsFeatured,
                    Make=f.Make,
                    Model=f.Make,
                    Price=f.Price,
                    Reference_ID=f.Reference_ID,
                    Reference_No=f.Reference_No,
                    Spects=f.Spects,
                    Title=f.Title,
                    Transmission=f.Transmission
            
                });
        }

        // GET: api/VehicleAdvertisements/5
        [ResponseType(typeof(CarSalesVehicleAdvertisement))]
        public IHttpActionResult GetVehicleAdvertisement(int id)
        {
            CarSalesVehicleAdvertisement carSalesVehicleAdvertisement = db.VehicleAdvertisements.Where(e=>e.Reference_ID==id)
                .Select(f => new CarSalesVehicleAdvertisement()
                    {
                        AudoMeter = f.AudoMeter,
                        BodyType = f.BodyType,
                        Description = f.Description,
                        EngineCapacity = f.EngineCapacity,
                        Feature = f.Feature,
                        Fuel = f.Fuel,
                        IsFeatured = f.IsFeatured,
                        Make = f.Make,
                        Model = f.Make,
                        Price = f.Price,
                        Reference_ID = f.Reference_ID,
                        Reference_No = f.Reference_No,
                        Spects = f.Spects,
                        Title = f.Title,
                        Transmission = f.Transmission

                    }
                ).FirstOrDefault(); 
            if (carSalesVehicleAdvertisement == null)
            {
                return NotFound();
            }

            return Ok(carSalesVehicleAdvertisement);
        }

        // PUT: api/VehicleAdvertisements/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicleAdvertisement(int id, CarSalesVehicleAdvertisement carSalesVehicleAdvertisement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carSalesVehicleAdvertisement.Reference_ID)
            {
                return BadRequest();
            }

            VehicleAdvertisement vehicleAdvertisement = new VehicleAdvertisement()
            {
                AudoMeter = carSalesVehicleAdvertisement.AudoMeter,
                BodyType = carSalesVehicleAdvertisement.BodyType,
                Description = carSalesVehicleAdvertisement.Description,
                EngineCapacity = carSalesVehicleAdvertisement.EngineCapacity,
                Feature = carSalesVehicleAdvertisement.Feature,
                Fuel = carSalesVehicleAdvertisement.Fuel,
                IsFeatured = carSalesVehicleAdvertisement.IsFeatured,
                Make = carSalesVehicleAdvertisement.Make,
                Model = carSalesVehicleAdvertisement.Make,
                Price = carSalesVehicleAdvertisement.Price,
                Reference_ID = carSalesVehicleAdvertisement.Reference_ID,
                Reference_No = carSalesVehicleAdvertisement.Reference_No,
                Spects = carSalesVehicleAdvertisement.Spects,
                Title = carSalesVehicleAdvertisement.Title,
                Transmission = carSalesVehicleAdvertisement.Transmission

            };

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
        [ResponseType(typeof(CarSalesVehicleAdvertisement))]
        public IHttpActionResult PostVehicleAdvertisement(CarSalesVehicleAdvertisement carSalesVehicleAdvertisement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            VehicleAdvertisement vehicleAdvertisement = new VehicleAdvertisement()
            {
                AudoMeter = carSalesVehicleAdvertisement.AudoMeter,
                BodyType = carSalesVehicleAdvertisement.BodyType,
                Description = carSalesVehicleAdvertisement.Description,
                EngineCapacity = carSalesVehicleAdvertisement.EngineCapacity,
                Feature = carSalesVehicleAdvertisement.Feature,
                Fuel = carSalesVehicleAdvertisement.Fuel,
                IsFeatured = carSalesVehicleAdvertisement.IsFeatured,
                Make = carSalesVehicleAdvertisement.Make,
                Model = carSalesVehicleAdvertisement.Make,
                Price = carSalesVehicleAdvertisement.Price,
                Reference_ID = carSalesVehicleAdvertisement.Reference_ID,
                Reference_No = carSalesVehicleAdvertisement.Reference_No,
                Spects = carSalesVehicleAdvertisement.Spects,
                Title = carSalesVehicleAdvertisement.Title,
                Transmission = carSalesVehicleAdvertisement.Transmission

            };

            db.VehicleAdvertisements.Add(vehicleAdvertisement);
            db.SaveChanges();
            carSalesVehicleAdvertisement.Reference_ID = vehicleAdvertisement.Reference_ID;

            return CreatedAtRoute("DefaultApi", new { id = vehicleAdvertisement.Reference_ID }, carSalesVehicleAdvertisement);
        }

        // DELETE: api/VehicleAdvertisements/5
        [ResponseType(typeof(CarSalesVehicleAdvertisement))]
        public IHttpActionResult DeleteVehicleAdvertisement(int id)
        {
            VehicleAdvertisement vehicleAdvertisement = db.VehicleAdvertisements.Find(id);
            if (vehicleAdvertisement == null)
            {
                return NotFound();
            }

            CarSalesVehicleAdvertisement carSalesVehicleAdvertisement= new CarSalesVehicleAdvertisement()
            {
                AudoMeter = vehicleAdvertisement.AudoMeter,
                BodyType = vehicleAdvertisement.BodyType,
                Description = vehicleAdvertisement.Description,
                EngineCapacity = vehicleAdvertisement.EngineCapacity,
                Feature = vehicleAdvertisement.Feature,
                Fuel = vehicleAdvertisement.Fuel,
                IsFeatured = vehicleAdvertisement.IsFeatured,
                Make = vehicleAdvertisement.Make,
                Model = vehicleAdvertisement.Make,
                Price = vehicleAdvertisement.Price,
                Reference_ID = vehicleAdvertisement.Reference_ID,
                Reference_No = vehicleAdvertisement.Reference_No,
                Spects = vehicleAdvertisement.Spects,
                Title = vehicleAdvertisement.Title,
                Transmission = vehicleAdvertisement.Transmission

            };
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