using CarSales.API.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
namespace CarSales.API.Models.Classes
{
    public class CarSalesVehicleAdvertisement  
    {
        public int Reference_ID { get; set; }
        public string Title { get; set; }
        public string Reference_No { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> BodyType { get; set; }
        public Nullable<int> EngineCapacity { get; set; }
        public Nullable<decimal> AudoMeter { get; set; }
        public Nullable<int> Fuel { get; set; }
        public string Description { get; set; }
        public string Feature { get; set; }
        public string Spects { get; set; }
        public Nullable<int> Make { get; set; }
        public Nullable<int> Model { get; set; }
        public bool IsFeatured { get; set; }
        public string Transmission { get; set; }
        public Nullable<DateTime>  DateAdvertised { get; set; }
        public bool Sold { get; set; }
        public bool Archived { get; set; }
        public IEnumerable<CarSalesVehicleBody> VehicleBody { get; set; }
        public IEnumerable<CarSalesVehicleFuel> VehicleFuel { get; set; }
        public IEnumerable<CarSalesVehicleMake> VehicleMake { get; set; }
        public IEnumerable<CarSalesVehicleModel> VehicleModel { get; set; }

        public CarSalesVehicleAdvertisement()
        {
            CarSalesDBEntities db = new CarSalesDBEntities();

            VehicleBody = db.VehicleBodies.Select(e => new CarSalesVehicleBody() { BodyDescription = e.BodyDescription, ID = e.ID, ImageURL = e.ImageURL });
            VehicleFuel = db.VehicleFuels.Select(e => new CarSalesVehicleFuel() { FuelType = e.FuelType, ID=e.ID });
            VehicleMake = db.VehicleMakes.Select(e => new CarSalesVehicleMake() { VehicleMake1 = e.VehicleMake1, ID = e.ID});
            VehicleModel = db.VehicleModels.Select(e => new CarSalesVehicleModel() { VehicleModel1 = e.VehicleModel1, ID = e.ID,VehicleMakeID=e.VehicleMakeID });
        }
    }
}