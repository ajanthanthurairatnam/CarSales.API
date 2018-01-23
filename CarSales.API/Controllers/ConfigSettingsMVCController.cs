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
    public class ConfigSettingsMVCController : Controller
    {
        private CarSalesDBEntities db = new CarSalesDBEntities();

        // GET: ConfigSettingsMVC
        public ActionResult Index()
        {
            return View(db.ConfigSettings.ToList());
        }

        // GET: ConfigSettingsMVC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConfigSetting configSetting = db.ConfigSettings.Find(id);
            if (configSetting == null)
            {
                return HttpNotFound();
            }
            return View(configSetting);
        }

        // GET: ConfigSettingsMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConfigSettingsMVC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,VehicleAdvertisementNextRefNo")] ConfigSetting configSetting)
        {
            if (ModelState.IsValid)
            {
                db.ConfigSettings.Add(configSetting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(configSetting);
        }

        // GET: ConfigSettingsMVC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConfigSetting configSetting = db.ConfigSettings.Find(id);
            if (configSetting == null)
            {
                return HttpNotFound();
            }
            return View(configSetting);
        }

        // POST: ConfigSettingsMVC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,VehicleAdvertisementNextRefNo")] ConfigSetting configSetting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(configSetting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(configSetting);
        }

        // GET: ConfigSettingsMVC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConfigSetting configSetting = db.ConfigSettings.Find(id);
            if (configSetting == null)
            {
                return HttpNotFound();
            }
            return View(configSetting);
        }

        // POST: ConfigSettingsMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConfigSetting configSetting = db.ConfigSettings.Find(id);
            db.ConfigSettings.Remove(configSetting);
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
