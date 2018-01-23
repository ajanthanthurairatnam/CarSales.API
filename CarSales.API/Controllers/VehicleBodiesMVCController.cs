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
    public class VehicleBodiesMVCController : Controller
    {
        private CarSalesDBEntities db = new CarSalesDBEntities();

        // GET: VehicleBodiesMVC
        public ActionResult Index()
        {
            return View(db.VehicleBodies.ToList());
        }

        // GET: VehicleBodiesMVC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleBody vehicleBody = db.VehicleBodies.Find(id);
            if (vehicleBody == null)
            {
                return HttpNotFound();
            }
            return View(vehicleBody);
        }

        // GET: VehicleBodiesMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleBodiesMVC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BodyDescription,ImageURL")] VehicleBody vehicleBody)
        {
            if (ModelState.IsValid)
            {
                db.VehicleBodies.Add(vehicleBody);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicleBody);
        }

        // GET: VehicleBodiesMVC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleBody vehicleBody = db.VehicleBodies.Find(id);
            if (vehicleBody == null)
            {
                return HttpNotFound();
            }
            return View(vehicleBody);
        }

        // POST: VehicleBodiesMVC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BodyDescription,ImageURL")] VehicleBody vehicleBody)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleBody).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicleBody);
        }

        // GET: VehicleBodiesMVC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleBody vehicleBody = db.VehicleBodies.Find(id);
            if (vehicleBody == null)
            {
                return HttpNotFound();
            }
            return View(vehicleBody);
        }

        // POST: VehicleBodiesMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehicleBody vehicleBody = db.VehicleBodies.Find(id);
            db.VehicleBodies.Remove(vehicleBody);
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
