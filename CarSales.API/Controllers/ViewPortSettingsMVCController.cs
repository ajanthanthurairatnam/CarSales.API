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
    public class ViewPortSettingsMVCController : Controller
    {
        private CarSalesDBEntities db = new CarSalesDBEntities();

        // GET: ViewPortSettingsMVC
        public ActionResult Index()
        {
            var viewPortSettings = db.ViewPortSettings.Include(v => v.ViewPort);
            return View(viewPortSettings.ToList());
        }

        // GET: ViewPortSettingsMVC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewPortSetting viewPortSetting = db.ViewPortSettings.Find(id);
            if (viewPortSetting == null)
            {
                return HttpNotFound();
            }
            return View(viewPortSetting);
        }

        // GET: ViewPortSettingsMVC/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.ViewPorts, "ID", "Description");
            return View();
        }

        // POST: ViewPortSettingsMVC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ViewPortID,SettingCode,PageSize")] ViewPortSetting viewPortSetting)
        {
            if (ModelState.IsValid)
            {
                db.ViewPortSettings.Add(viewPortSetting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.ViewPorts, "ID", "Description", viewPortSetting.ID);
            return View(viewPortSetting);
        }

        // GET: ViewPortSettingsMVC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewPortSetting viewPortSetting = db.ViewPortSettings.Find(id);
            if (viewPortSetting == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.ViewPorts, "ID", "Description", viewPortSetting.ID);
            return View(viewPortSetting);
        }

        // POST: ViewPortSettingsMVC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ViewPortID,SettingCode,PageSize")] ViewPortSetting viewPortSetting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viewPortSetting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.ViewPorts, "ID", "Description", viewPortSetting.ID);
            return View(viewPortSetting);
        }

        // GET: ViewPortSettingsMVC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewPortSetting viewPortSetting = db.ViewPortSettings.Find(id);
            if (viewPortSetting == null)
            {
                return HttpNotFound();
            }
            return View(viewPortSetting);
        }

        // POST: ViewPortSettingsMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewPortSetting viewPortSetting = db.ViewPortSettings.Find(id);
            db.ViewPortSettings.Remove(viewPortSetting);
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
