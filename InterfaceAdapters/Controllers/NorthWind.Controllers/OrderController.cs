using Microsoft.AspNetCore.Mvc;
using NorthWind.Presenters;
using NorthWind.UseCasesDTOs.CreateOrder;
using NorthWind.UsesCasesPorts.CreateOrder;

namespace NorthWind.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController
{
    private readonly ICreateOrderInputPort _inputPort;
    private readonly ICreateOrderOutputPort _outputPort;

    public OrderController(ICreateOrderInputPort inputPort, ICreateOrderOutputPort outputPort)
    {
        _inputPort = inputPort;
        _outputPort = outputPort;
    }

    [HttpPost("create-order")]
    public async Task<string> CreateOrder(CreateOrderParams orderParams)
    {
        await _inputPort.Handle(orderParams);
        IPresenter<string> presenter = (CreateOrderPresenter)_outputPort;
        return presenter.Content;
    }
}
