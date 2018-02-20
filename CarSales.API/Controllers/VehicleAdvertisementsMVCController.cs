using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarSales.API.Models.Classes;
using CarSales.API.Models.EF;

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
                Transmission = e.Transmission,
                Archived = false,
                DateAdvertised = DateTime.Today,
                Sold = false

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
        public ActionResult Details(int? Reference_ID = 0)
        {
            CarSalesVehicleAdvertisement CarSalesVehicleAdvertisement;
            CarSalesDBEntities db = new CarSalesDBEntities();
            VehicleAdvertisement vehicleAdvertisement = db.VehicleAdvertisements.Find(Reference_ID);
            if (Reference_ID != 0)
            {
                CarSalesVehicleAdvertisement = new CarSalesVehicleAdvertisement()
                {
                    Archived = vehicleAdvertisement.Archived,
                    AudoMeter = vehicleAdvertisement.AudoMeter,
                    BodyType = vehicleAdvertisement.BodyType,
                    DateAdvertised = vehicleAdvertisement.DateAdvertised,
                    Description = vehicleAdvertisement.Description,
                    EngineCapacity = vehicleAdvertisement.EngineCapacity,
                    Feature = vehicleAdvertisement.Feature,
                    Fuel = vehicleAdvertisement.Fuel,
                    IsFeatured = vehicleAdvertisement.IsFeatured,
                    Make = vehicleAdvertisement.Make,
                    Model = vehicleAdvertisement.Model,
                    Price = vehicleAdvertisement.Price,
                    Reference_ID = vehicleAdvertisement.Reference_ID,
                    Reference_No = vehicleAdvertisement.Reference_No,
                    Sold = vehicleAdvertisement.Sold,
                    Spects = vehicleAdvertisement.Spects,
                    Title = vehicleAdvertisement.Title,
                    Transmission = vehicleAdvertisement.Transmission
                };
                return View(CarSalesVehicleAdvertisement);
            }        
           
                return HttpNotFound();
        }

        // GET: VehicleAdvertisementsMVC/Create
        public ActionResult Edit(int? Reference_ID=0)
        {
            CarSalesVehicleAdvertisement CarSalesVehicleAdvertisement;
            CarSalesDBEntities db = new CarSalesDBEntities();
            VehicleAdvertisement vehicleAdvertisement = db.VehicleAdvertisements.Find(Reference_ID);
            if (Reference_ID != 0)
            {
                CarSalesVehicleAdvertisement = new CarSalesVehicleAdvertisement()
                {
                    Archived = vehicleAdvertisement.Archived,
                    AudoMeter = vehicleAdvertisement.AudoMeter,
                    BodyType = vehicleAdvertisement.BodyType,
                    DateAdvertised = vehicleAdvertisement.DateAdvertised,
                    Description = vehicleAdvertisement.Description,
                    EngineCapacity = vehicleAdvertisement.EngineCapacity,
                    Feature = vehicleAdvertisement.Feature,
                    Fuel = vehicleAdvertisement.Fuel,
                    IsFeatured = vehicleAdvertisement.IsFeatured,
                    Make = vehicleAdvertisement.Make,
                    Model = vehicleAdvertisement.Model,
                    Price = vehicleAdvertisement.Price,
                    Reference_ID = vehicleAdvertisement.Reference_ID,
                    Reference_No = vehicleAdvertisement.Reference_No,
                    Sold = vehicleAdvertisement.Sold,
                    Spects = vehicleAdvertisement.Spects,
                    Title = vehicleAdvertisement.Title,
                    Transmission = vehicleAdvertisement.Transmission
                };
            }
            else
            {
                var ConfigSettings = db.ConfigSettings.FirstOrDefault();
                CarSalesVehicleAdvertisement = new CarSalesVehicleAdvertisement() { Reference_No = ConfigSettings.VehicleAdvertisementNextRefNo.Value.ToString("00000") };
                ConfigSettings.VehicleAdvertisementNextRefNo = ConfigSettings.VehicleAdvertisementNextRefNo + 1;
                db.SaveChanges();
            }
            return View(CarSalesVehicleAdvertisement);
        }

        // POST: VehicleAdvertisementsMVC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CarSalesVehicleAdvertisement CarSalesVehicleAdvertisement)
        {
            CarSalesDBEntities db = new CarSalesDBEntities();

            if (ModelState.IsValid)
            {
                int SellerID = CarSales.API.Helper.HelperClass.GetSeller(System.Web.HttpContext.Current.User.Identity.Name).ID;

                VehicleAdvertisement VehicleAdvertisement = db.VehicleAdvertisements.Find(CarSalesVehicleAdvertisement.Reference_ID);
                if (VehicleAdvertisement == null)
                {
                    VehicleAdvertisement = new VehicleAdvertisement();
                }

                VehicleAdvertisement.Archived = CarSalesVehicleAdvertisement.Archived;
                VehicleAdvertisement.AudoMeter = CarSalesVehicleAdvertisement.AudoMeter;
                    VehicleAdvertisement.BodyType = CarSalesVehicleAdvertisement.BodyType;
                VehicleAdvertisement.DateAdvertised = CarSalesVehicleAdvertisement.DateAdvertised;
                VehicleAdvertisement.Description = CarSalesVehicleAdvertisement.Description;
                VehicleAdvertisement.EngineCapacity = CarSalesVehicleAdvertisement.EngineCapacity;
                VehicleAdvertisement.Feature = CarSalesVehicleAdvertisement.Feature;
                VehicleAdvertisement.Fuel = CarSalesVehicleAdvertisement.Fuel;
                VehicleAdvertisement.IsFeatured = CarSalesVehicleAdvertisement.IsFeatured;
                VehicleAdvertisement.Make = CarSalesVehicleAdvertisement.Make;
                VehicleAdvertisement.Model = CarSalesVehicleAdvertisement.Model;
                VehicleAdvertisement.Price = CarSalesVehicleAdvertisement.Price;
                VehicleAdvertisement.Reference_ID = CarSalesVehicleAdvertisement.Reference_ID;
                VehicleAdvertisement.Reference_No = CarSalesVehicleAdvertisement.Reference_No;
                VehicleAdvertisement.Sold = CarSalesVehicleAdvertisement.Sold;
                VehicleAdvertisement.Spects = CarSalesVehicleAdvertisement.Spects;
                VehicleAdvertisement.Title = CarSalesVehicleAdvertisement.Title;
                VehicleAdvertisement.Transmission = CarSalesVehicleAdvertisement.Transmission;
               
                if (CarSalesVehicleAdvertisement.Reference_ID == 0)
                {
                    db.VehicleAdvertisements.Add(VehicleAdvertisement);
                    db.SaveChanges();
                    var VehicleSeller = new VehicleSeller()
                    {
                        SellerID = SellerID,


                        VehicleID = VehicleAdvertisement.Reference_ID,

                    };
                    db.VehicleSellers.Add(VehicleSeller);
                    db.SaveChanges();
                }
                else
                {
                      db.SaveChanges();
                }

                return RedirectToAction("SellerRegisterDetail", "Account", new { ID = SellerID });
            }

            return View(CarSalesVehicleAdvertisement);
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
