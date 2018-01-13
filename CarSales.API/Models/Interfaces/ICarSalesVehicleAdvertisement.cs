namespace CarSales.API.Models.Interface
{
    public interface ICarSalesVehicleAdvertisement
    {
        decimal? AudoMeter { get; set; }
        int? BodyType { get; set; }
        string Description { get; set; }
        int? EngineCapacity { get; set; }
        string Feature { get; set; }
        int? Fuel { get; set; }
        bool IsFeatured { get; set; }
        int? Make { get; set; }
        int? Model { get; set; }
        decimal? Price { get; set; }
        int Reference_ID { get; set; }
        string Reference_No { get; set; }
        string Spects { get; set; }
        string Title { get; set; }
        string Transmission { get; set; }
    }
}