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
    public class ViewPortsMVCController : Controller
    {
        private CarSalesDBEntities db = new CarSalesDBEntities();

        // GET: ViewPortsMVC
        public ActionResult Index()
        {
            var viewPorts = db.ViewPorts.Include(v => v.ViewPortSetting);
            return View(viewPorts.ToList());
        }

        // GET: ViewPortsMVC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewPort viewPort = db.ViewPorts.Find(id);
            if (viewPort == null)
            {
                return HttpNotFound();
            }
            return View(viewPort);
        }

        // GET: ViewPortsMVC/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.ViewPortSettings, "ID", "SettingCode");
            return View();
        }

        // POST: ViewPortsMVC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description")] ViewPort viewPort)
        {
            if (ModelState.IsValid)
            {
                db.ViewPorts.Add(viewPort);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.ViewPortSettings, "ID", "SettingCode", viewPort.ID);
            return View(viewPort);
        }

        // GET: ViewPortsMVC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewPort viewPort = db.ViewPorts.Find(id);
            if (viewPort == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.ViewPortSettings, "ID", "SettingCode", viewPort.ID);
            return View(viewPort);
        }

        // POST: ViewPortsMVC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description")] ViewPort viewPort)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viewPort).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.ViewPortSettings, "ID", "SettingCode", viewPort.ID);
            return View(viewPort);
        }

        // GET: ViewPortsMVC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewPort viewPort = db.ViewPorts.Find(id);
            if (viewPort == null)
            {
                return HttpNotFound();
            }
            return View(viewPort);
        }

        // POST: ViewPortsMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewPort viewPort = db.ViewPorts.Find(id);
            db.ViewPorts.Remove(viewPort);
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
