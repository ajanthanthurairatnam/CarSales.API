namespace CarSales.API.Models.Interface
{
    public interface ICarSalesConfigSetting
    {
        int ID { get; set; }
        int? VehicleAdvertisementNextRefNo { get; set; }
    }
}