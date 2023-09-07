using NorthWind.Entities.Enums;

namespace NorthWind.Entities.POCOEntities;

public class Order
{
    public int Id { get; set; }
    public string CustomerId { get; set; } = null!;
    public DateTime OrderDate { get; set; }
    public string ShipAddress { get; set; } = null!;
    public string ShipCity { get; set; } = null!;
    public string ShipCountry { get; set; } = null!;
    public string ShipPostalCode { get; set; } = null!;
    public DiscountType DiscountType { get; set; }
    public double Discount { get; set; }
    public ShippingType ShippingType { get; set; }
}