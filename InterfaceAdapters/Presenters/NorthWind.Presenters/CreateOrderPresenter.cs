using NorthWind.UsesCasesPorts.CreateOrder;

namespace NorthWind.Presenters;

public class CreateOrderPresenter : ICreateOrderOutputPort, IPresenter<string>
{
    public string Content { get; private set; } = null!;

    public Task Handle(int orderId)
    {
        Content = $"Order Id: {orderId}";
        return Task.CompletedTask;
    }
}