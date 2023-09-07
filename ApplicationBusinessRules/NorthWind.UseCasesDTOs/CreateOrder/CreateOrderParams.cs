namespace NorthWind.UseCasesDTOs.CreateOrder;

public class CreateOrderParams
{
    public string CustomerId { get; set; } = null!;
    public string ShipAddress { get; set; } = null!;
    public string ShipCity { get; set; } = null!;
    public string ShipCountry { get; set; } = null!;
    public string ShipPostalCode { get; set; } = null!;
    public List<CreateOrderDetailParams> OrderDetails { get; set; } = new();
}