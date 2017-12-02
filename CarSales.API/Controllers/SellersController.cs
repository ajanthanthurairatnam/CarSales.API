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
    public class SellersController : ApiController
    {
        private CarSalesDBEntities db = new CarSalesDBEntities();

        // GET: api/Sellers
        public IQueryable<Seller> GetSellers()
        {
            return db.Sellers;
        }

        // GET: api/Sellers/5
        [ResponseType(typeof(Seller))]
        public IHttpActionResult GetSeller(int id)
        {
            Seller seller = db.Sellers.Find(id);
            if (seller == null)
            {
                return NotFound();
            }

            return Ok(seller);
        }

        // PUT: api/Sellers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSeller(int id, Seller seller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != seller.ID)
            {
                return BadRequest();
            }

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
        [ResponseType(typeof(Seller))]
        public IHttpActionResult PostSeller(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sellers.Add(seller);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = seller.ID }, seller);
        }

        // DELETE: api/Sellers/5
        [ResponseType(typeof(Seller))]
        public IHttpActionResult DeleteSeller(int id)
        {
            Seller seller = db.Sellers.Find(id);
            if (seller == null)
            {
                return NotFound();
            }

            db.Sellers.Remove(seller);
            db.SaveChanges();

            return Ok(seller);
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