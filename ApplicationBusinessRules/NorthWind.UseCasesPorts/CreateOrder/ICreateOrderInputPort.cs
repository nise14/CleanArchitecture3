using NorthWind.UseCasesDTOs.CreateOrder;

namespace NorthWind.UsesCasesPorts.CreateOrder;

public interface ICreateOrderInputPort
{
    Task Handle(CreateOrderParams order);
}