namespace CarSales.API.Models.Interface
{
    public interface ICarSalesVehicleModel
    {
        int ID { get; set; }
        int? VehicleMakeID { get; set; }
        string VehicleModel1 { get; set; }
    }
}