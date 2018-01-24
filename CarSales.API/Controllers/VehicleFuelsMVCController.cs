using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarSales.API.Models;
using CarSales.API.Models.EF;

namespace CarSales.API.Controllers
{
    public class VehicleFuelsMVCController : Controller
    {
        private CarSalesDBEntities db = new CarSalesDBEntities();

        // GET: VehicleFuelsMVC
        public ActionResult Index()
        {
            return View(db.VehicleFuels.ToList());
        }

        // GET: VehicleFuelsMVC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleFuel vehicleFuel = db.VehicleFuels.Find(id);
            if (vehicleFuel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleFuel);
        }

        // GET: VehicleFuelsMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleFuelsMVC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FuelType")] VehicleFuel vehicleFuel)
        {
            if (ModelState.IsValid)
            {
                db.VehicleFuels.Add(vehicleFuel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicleFuel);
        }

        // GET: VehicleFuelsMVC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleFuel vehicleFuel = db.VehicleFuels.Find(id);
            if (vehicleFuel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleFuel);
        }

        // POST: VehicleFuelsMVC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FuelType")] VehicleFuel vehicleFuel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleFuel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicleFuel);
        }

        // GET: VehicleFuelsMVC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleFuel vehicleFuel = db.VehicleFuels.Find(id);
            if (vehicleFuel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleFuel);
        }

        // POST: VehicleFuelsMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehicleFuel vehicleFuel = db.VehicleFuels.Find(id);
            db.VehicleFuels.Remove(vehicleFuel);
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
