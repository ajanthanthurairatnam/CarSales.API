﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarSales.API.Models;
using CarSales.API.Models.Classes;

namespace CarSales.API.Controllers
{
    public class VehicleAdvertisementsMVCController : Controller
    {
        private CarSalesDBEntities db = new CarSalesDBEntities();

        // GET: VehicleAdvertisementsMVC
        public ActionResult Index()
        {
            var vehicleAdvertisements = db.VehicleAdvertisements.Include(v => v.VehicleBody).Include(v => v.VehicleFuel).Include(v => v.VehicleMake).Include(v => v.VehicleModel);
            return View(vehicleAdvertisements.ToList());
        }


        public ActionResult GetAdvertisements(string SearchText="",int PageNos=10 ,int PageIndex=1 )
        {
            var vehicleAdvertisements = db.VehicleAdvertisements.Where(e => SearchText.Length>0?e.Title.Contains(SearchText.Trim()):true);
            int PageCount = (vehicleAdvertisements.Count() + PageNos - 1) / PageNos;

            int SkipCount = (PageIndex-1) * PageNos;
            var vehicleAdd = vehicleAdvertisements.OrderBy(p => p.Reference_ID).Skip(SkipCount).Take(PageNos);
            CarSaleSearch CarSaleSearch = new CarSaleSearch();
            CarSaleSearch.Advertisement = vehicleAdd.Select(e => new CarSalesVehicleAdvertisement() {
                AudoMeter=e.AudoMeter,
                BodyType=e.BodyType,
                Description=e.Description,
                EngineCapacity=e.EngineCapacity,
                Feature=e.Feature,
                Fuel=e.Fuel,
                IsFeatured=e.IsFeatured,
                Make=e.Make,
                Model=e.Model,
                Price=e.Price,
                Reference_ID=e.Reference_ID,
                Reference_No=e.Reference_No,
                Spects=e.Spects,
                Title=e.Title,
                Transmission=e.Transmission
            });
            CarSaleSearch.PageIndex = PageIndex;
            CarSaleSearch.PageNos = PageCount;
            CarSaleSearch.SearchText = SearchText;
            return View(CarSaleSearch);
        }

        [HttpPost]
        public ActionResult GetAdvertisements(string SearchText = "", int PageNos = 10, int PageIndex = 1,int dum=0)
        {
            var vehicleAdvertisements = db.VehicleAdvertisements.Where(e => SearchText.Length > 0 ? e.Title.Contains(SearchText.Trim()) : true);
            int PageCount = (vehicleAdvertisements.Count() + PageNos - 1) / PageNos;

            int SkipCount = (PageIndex - 1) * PageNos;
            var vehicleAdd = vehicleAdvertisements.OrderBy(p => p.Reference_ID).Skip(SkipCount).Take(PageNos);
            CarSaleSearch CarSaleSearch = new CarSaleSearch();
            CarSaleSearch.Advertisement = vehicleAdd.Select(e => new CarSalesVehicleAdvertisement()
            {
                AudoMeter = e.AudoMeter,
                BodyType = e.BodyType,
                Description = e.Description,
                EngineCapacity = e.EngineCapacity,
                Feature = e.Feature,
                Fuel = e.Fuel,
                IsFeatured = e.IsFeatured,
                Make = e.Make,
                Model = e.Model,
                Price = e.Price,
                Reference_ID = e.Reference_ID,
                Reference_No = e.Reference_No,
                Spects = e.Spects,
                Title = e.Title,
                Transmission = e.Transmission
            });
            CarSaleSearch.PageIndex = PageIndex;
            CarSaleSearch.PageNos = PageCount;
            CarSaleSearch.SearchText = SearchText;
            return View(CarSaleSearch);
        }


        // GET: VehicleAdvertisementsMVC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleAdvertisement vehicleAdvertisement = db.VehicleAdvertisements.Find(id);
            if (vehicleAdvertisement == null)
            {
                return HttpNotFound();
            }
            return View(vehicleAdvertisement);
        }

        // GET: VehicleAdvertisementsMVC/Create
        public ActionResult Create()
        {
            ViewBag.BodyType = new SelectList(db.VehicleBodies, "ID", "BodyDescription");
            ViewBag.Fuel = new SelectList(db.VehicleFuels, "ID", "FuelType");
            ViewBag.Make = new SelectList(db.VehicleMakes, "ID", "VehicleMake1");
            ViewBag.Model = new SelectList(db.VehicleModels, "ID", "VehicleModel1");
            return View();
        }

        // POST: VehicleAdvertisementsMVC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Reference_ID,Title,Reference_No,Price,BodyType,EngineCapacity,AudoMeter,Fuel,Description,Feature,Spects,Make,Model,IsFeatured,Transmission")] VehicleAdvertisement vehicleAdvertisement)
        {
            if (ModelState.IsValid)
            {
                db.VehicleAdvertisements.Add(vehicleAdvertisement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BodyType = new SelectList(db.VehicleBodies, "ID", "BodyDescription", vehicleAdvertisement.BodyType);
            ViewBag.Fuel = new SelectList(db.VehicleFuels, "ID", "FuelType", vehicleAdvertisement.Fuel);
            ViewBag.Make = new SelectList(db.VehicleMakes, "ID", "VehicleMake1", vehicleAdvertisement.Make);
            ViewBag.Model = new SelectList(db.VehicleModels, "ID", "VehicleModel1", vehicleAdvertisement.Model);
            return View(vehicleAdvertisement);
        }

        // GET: VehicleAdvertisementsMVC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleAdvertisement vehicleAdvertisement = db.VehicleAdvertisements.Find(id);
            if (vehicleAdvertisement == null)
            {
                return HttpNotFound();
            }
            ViewBag.BodyType = new SelectList(db.VehicleBodies, "ID", "BodyDescription", vehicleAdvertisement.BodyType);
            ViewBag.Fuel = new SelectList(db.VehicleFuels, "ID", "FuelType", vehicleAdvertisement.Fuel);
            ViewBag.Make = new SelectList(db.VehicleMakes, "ID", "VehicleMake1", vehicleAdvertisement.Make);
            ViewBag.Model = new SelectList(db.VehicleModels, "ID", "VehicleModel1", vehicleAdvertisement.Model);
            return View(vehicleAdvertisement);
        }

        // POST: VehicleAdvertisementsMVC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Reference_ID,Title,Reference_No,Price,BodyType,EngineCapacity,AudoMeter,Fuel,Description,Feature,Spects,Make,Model,IsFeatured,Transmission")] VehicleAdvertisement vehicleAdvertisement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleAdvertisement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BodyType = new SelectList(db.VehicleBodies, "ID", "BodyDescription", vehicleAdvertisement.BodyType);
            ViewBag.Fuel = new SelectList(db.VehicleFuels, "ID", "FuelType", vehicleAdvertisement.Fuel);
            ViewBag.Make = new SelectList(db.VehicleMakes, "ID", "VehicleMake1", vehicleAdvertisement.Make);
            ViewBag.Model = new SelectList(db.VehicleModels, "ID", "VehicleModel1", vehicleAdvertisement.Model);
            return View(vehicleAdvertisement);
        }

        // GET: VehicleAdvertisementsMVC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleAdvertisement vehicleAdvertisement = db.VehicleAdvertisements.Find(id);
            if (vehicleAdvertisement == null)
            {
                return HttpNotFound();
            }
            return View(vehicleAdvertisement);
        }

        // POST: VehicleAdvertisementsMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehicleAdvertisement vehicleAdvertisement = db.VehicleAdvertisements.Find(id);
            db.VehicleAdvertisements.Remove(vehicleAdvertisement);
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
