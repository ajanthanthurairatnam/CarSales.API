namespace CarSales.API.Models.Interface
{
    public interface ICarSalesVehicleBody
    {
        string BodyDescription { get; set; }
        int ID { get; set; }
        string ImageURL { get; set; }
    }
}