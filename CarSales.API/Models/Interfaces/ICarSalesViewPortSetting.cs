namespace CarSales.API.Models.Interface
{
    public interface ICarSalesViewPortSetting
    {
        int ID { get; set; }
        int? PageSize { get; set; }
        string SettingCode { get; set; }
        int? ViewPortID { get; set; }
    }
}