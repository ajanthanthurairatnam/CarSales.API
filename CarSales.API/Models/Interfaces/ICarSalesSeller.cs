namespace CarSales.API.Models.Interface
{
    public interface ICarSalesSeller
    {
        string ContactEMail { get; set; }
        string ContactMobile { get; set; }
        string ContactPhone { get; set; }
        int ID { get; set; }
        string Name { get; set; }
        string PickupAddress { get; set; }
        string PostCode { get; set; }
    }
}