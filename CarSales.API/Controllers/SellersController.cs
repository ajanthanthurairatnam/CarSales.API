using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using CarSales.API.Models;
using CarSales.API.Models.Classes;
using CarSales.API.Interfaces;

namespace CarSales.API.Controllers
{
    public class SellersController : ApiController
    {
        private CarSalesDBEntities db = new CarSalesDBEntities();

        private IVehicleRepository<Seller> repoSellers;

        public SellersController( )
        {
            this.repoSellers = new VehicleRepository<Seller>(db);
        }
        // GET: api/Sellers
        public IEnumerable<CarSalesSeller> GetSellers()
        {
           return this.repoSellers.GetAll().Select(seller => new CarSalesSeller() { ContactEMail = seller.ContactEMail, ContactMobile = seller.ContactMobile, ContactPhone = seller.ContactPhone, ID = seller.ID, Name = seller.Name, PickupAddress = seller.PickupAddress, PostCode = seller.PickupAddress }); 
           // return db.Sellers.Select(seller => new CarSalesSeller() { ContactEMail = seller.ContactEMail, ContactMobile = seller.ContactMobile, ContactPhone = seller.ContactPhone, Id = seller.ID, Name = seller.Name, PickupAddress = seller.PickupAddress, PostCode = seller.PickupAddress });
        }

        // GET: api/Sellers/5
        [ResponseType(typeof(CarSalesSeller))]
        public IHttpActionResult GetSeller(int id)
        {
           Seller seller = db.Sellers.Find(id);
            //Seller seller = this.repoSellers.Get(id);
            if (seller == null)
            {
                return NotFound();
            }

            return Ok(new CarSalesSeller() { ContactEMail =seller.ContactEMail,ContactMobile=seller.ContactMobile,ContactPhone=seller.ContactPhone, ID = seller.ID,Name=seller.Name,PickupAddress=seller.PickupAddress,PostCode=seller.PickupAddress});
        }

        // PUT: api/Sellers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSeller(int id, CarSalesSeller carSalesSeller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carSalesSeller.ID)
            {
                return BadRequest();
            }

          Seller  seller= new Seller() { ContactEMail=carSalesSeller.ContactEMail, ContactMobile = carSalesSeller.ContactMobile, ContactPhone = carSalesSeller.ContactPhone, ID = carSalesSeller.ID, Name = carSalesSeller.Name, PickupAddress = carSalesSeller.PickupAddress, PostCode = carSalesSeller.PickupAddress };



            db.Entry(seller).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellerExists(id))
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

        // POST: api/Sellers
        [ResponseType(typeof(CarSalesSeller))]
        public IHttpActionResult PostSeller(CarSalesSeller carSalesSeller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Seller seller = new Seller() { ContactEMail = carSalesSeller.ContactEMail, ContactMobile = carSalesSeller.ContactMobile, ContactPhone = carSalesSeller.ContactPhone, ID = carSalesSeller.ID, Name = carSalesSeller.Name, PickupAddress = carSalesSeller.PickupAddress, PostCode = carSalesSeller.PickupAddress };

            db.Sellers.Add(seller);
            db.SaveChanges();
            carSalesSeller.ID = seller.ID;

            return CreatedAtRoute("DefaultApi", new { id = seller.ID }, carSalesSeller);
        }

        // DELETE: api/Sellers/5
        [ResponseType(typeof(CarSalesSeller))]
        public IHttpActionResult DeleteSeller(int id)
        {
            Seller seller = db.Sellers.Find(id);
            if (seller == null)
            {
                return NotFound();
            }

            db.Sellers.Remove(seller);
            db.SaveChanges();

            CarSalesSeller carSalesSeller=   new CarSalesSeller() { ContactEMail = seller.ContactEMail, ContactMobile = seller.ContactMobile, ContactPhone = seller.ContactPhone, ID = seller.ID, Name = seller.Name, PickupAddress = seller.PickupAddress, PostCode = seller.PickupAddress };


            return Ok(carSalesSeller);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SellerExists(int id)
        {
            return db.Sellers.Count(e => e.ID == id) > 0;
        }
    }
}