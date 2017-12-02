using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarSales.API.Models;

namespace CarSales.API.Controllers
{
    public class VehicleSellersMVCController : Controller
    {
        private CarSalesDBEntities db = new CarSalesDBEntities();

        // GET: VehicleSellersMVC
        public ActionResult Index()
        {
            var vehicleSellers = db.VehicleSellers.Include(v => v.Seller).Include(v => v.VehicleAdvertisement);
            return View(vehicleSellers.ToList());
        }

        // GET: VehicleSellersMVC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleSeller vehicleSeller = db.VehicleSellers.Find(id);
            if (vehicleSeller == null)
            {
                return HttpNotFound();
            }
            return View(vehicleSeller);
        }

        // GET: VehicleSellersMVC/Create
        public ActionResult Create()
        {
            ViewBag.SellerID = new SelectList(db.Sellers, "ID", "Name");
            ViewBag.VehicleID = new SelectList(db.VehicleAdvertisements, "Reference_ID", "Title");
            return View();
        }

        // POST: VehicleSellersMVC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,VehicleID,SellerID")] VehicleSeller vehicleSeller)
        {
            if (ModelState.IsValid)
            {
                db.VehicleSellers.Add(vehicleSeller);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SellerID = new SelectList(db.Sellers, "ID", "Name", vehicleSeller.SellerID);
            ViewBag.VehicleID = new SelectList(db.VehicleAdvertisements, "Reference_ID", "Title", vehicleSeller.VehicleID);
            return View(vehicleSeller);
        }

        // GET: VehicleSellersMVC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleSeller vehicleSeller = db.VehicleSellers.Find(id);
            if (vehicleSeller == null)
            {
                return HttpNotFound();
            }
            ViewBag.SellerID = new SelectList(db.Sellers, "ID", "Name", vehicleSeller.SellerID);
            ViewBag.VehicleID = new SelectList(db.VehicleAdvertisements, "Reference_ID", "Title", vehicleSeller.VehicleID);
            return View(vehicleSeller);
        }

        // POST: VehicleSellersMVC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,VehicleID,SellerID")] VehicleSeller vehicleSeller)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleSeller).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SellerID = new SelectList(db.Sellers, "ID", "Name", vehicleSeller.SellerID);
            ViewBag.VehicleID = new SelectList(db.VehicleAdvertisements, "Reference_ID", "Title", vehicleSeller.VehicleID);
            return View(vehicleSeller);
        }

        // GET: VehicleSellersMVC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleSeller vehicleSeller = db.VehicleSellers.Find(id);
            if (vehicleSeller == null)
            {
                return HttpNotFound();
            }
            return View(vehicleSeller);
        }

        // POST: VehicleSellersMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehicleSeller vehicleSeller = db.VehicleSellers.Find(id);
            db.VehicleSellers.Remove(vehicleSeller);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
