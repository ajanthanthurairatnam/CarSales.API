namespace CarSales.API.Models.Interface
{
    public interface ICarSalesVehicleSeller
    {
        int ID { get; set; }
        int SellerID { get; set; }
        int? VehicleID { get; set; }
    }
}