using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using CarSales.Model;
//using CarSales.API.Models.Classes;
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
        public IEnumerable<Seller> GetSellers()
        {
           return this.repoSellers.GetAll().Select(seller=> new Seller { ContactEMail = seller.ContactEMail, ContactMobile = seller.ContactMobile, ContactPhone = seller.ContactPhone, ID = seller.ID, Name = seller.Name, PickupAddress = seller.PickupAddress, PostCode = seller.PickupAddress })   ; 
           // return db.Sellers.Select(seller => new CarSalesSeller() { ContactEMail = seller.ContactEMail, ContactMobile = seller.ContactMobile, ContactPhone = seller.ContactPhone, Id = seller.ID, Name = seller.Name, PickupAddress = seller.PickupAddress, PostCode = seller.PickupAddress });
        }

        // GET: api/Sellers/5
        [ResponseType(typeof(Seller))]
        public IHttpActionResult GetSeller(int id)
        {
            //Seller seller = db.Sellers.Find(id);
            Seller seller = this.repoSellers.Get(id);
            if (seller == null)
            {
                return NotFound();
            }
            return Ok(new Seller() { ContactEMail = seller.ContactEMail, ContactMobile = seller.ContactMobile, ContactPhone = seller.ContactPhone, ID = seller.ID, Name = seller.Name, PickupAddress = seller.PickupAddress, PostCode = seller.PickupAddress });
            //return Ok(new CarSalesSeller() { ContactEMail =seller.ContactEMail,ContactMobile=seller.ContactMobile,ContactPhone=seller.ContactPhone, ID = seller.ID,Name=seller.Name,PickupAddress=seller.PickupAddress,PostCode=seller.PickupAddress});
        }

        // PUT: api/Sellers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSeller(int id, VehicleSeller carSalesSeller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carSalesSeller.ID)
            {
                return BadRequest();
            }
            

            Seller seller = new Seller() { ContactEMail = carSalesSeller.Seller.ContactEMail, ContactMobile = carSalesSeller.Seller.ContactMobile, ContactPhone = carSalesSeller.Seller.ContactPhone, ID = carSalesSeller.ID, Name = carSalesSeller.Seller.Name, PickupAddress = carSalesSeller.Seller.PickupAddress, PostCode = carSalesSeller.Seller.PickupAddress };

            this.repoSellers.Edit(seller);

         //   db.Entry(seller).State = EntityState.Modified;

            try
            {
                this.repoSellers.Edit(seller);
                // db.SaveChanges();
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

        //// POST: api/Sellers
        [ResponseType(typeof(Seller))]
        public IHttpActionResult PostSeller(Seller carSalesSeller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Seller seller = new Seller() { ContactEMail = carSalesSeller.ContactEMail, ContactMobile = carSalesSeller.ContactMobile, ContactPhone = carSalesSeller.ContactPhone, ID = carSalesSeller.ID, Name = carSalesSeller.Name, PickupAddress = carSalesSeller.PickupAddress, PostCode = carSalesSeller.PickupAddress };

            this.repoSellers.Add(seller); 
            //db.Sellers.Add(seller);
            //db.SaveChanges();
            //carSalesSeller.ID = seller.ID;

            return CreatedAtRoute("DefaultApi", new { id = seller.ID }, carSalesSeller);
        }

        //// DELETE: api/Sellers/5
        [ResponseType(typeof(Seller))]
        public IHttpActionResult DeleteSeller(int id)
        {
            Seller seller = db.Sellers.Find(id);
            if (seller == null)
            {
                return NotFound();
            }

            //db.Sellers.Remove(seller);
            // db.SaveChanges();

            this.repoSellers.Remove(seller); 

            Seller carSalesSeller = new Seller() { ContactEMail = seller.ContactEMail, ContactMobile = seller.ContactMobile, ContactPhone = seller.ContactPhone, ID = seller.ID, Name = seller.Name, PickupAddress = seller.PickupAddress, PostCode = seller.PickupAddress };


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