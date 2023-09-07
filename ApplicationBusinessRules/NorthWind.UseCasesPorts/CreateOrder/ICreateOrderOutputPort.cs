namespace NorthWind.UsesCasesPorts.CreateOrder;

public interface ICreateOrderOutputPort
{
    Task Handle(int orderId);
}