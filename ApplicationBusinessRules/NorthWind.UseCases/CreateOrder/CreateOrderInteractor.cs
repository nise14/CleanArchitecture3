using FluentValidation;
using NorthWind.Entities.Exceptions;
using NorthWind.Entities.Interfaces;
using NorthWind.Entities.POCOEntities;
using NorthWind.UseCasesDTOs.CreateOrder;
using NorthWind.UsesCasesPorts.CreateOrder;

namespace NorthWind.UseCases.CreateOrder;

public class CreateOrderInteractor : ICreateOrderInputPort
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderDetailRepository _orderDetailRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICreateOrderOutputPort _outputPort;
    private readonly IEnumerable<IValidator<CreateOrderParams>> _validators;

    public CreateOrderInteractor(IOrderRepository orderRepository,
        IOrderDetailRepository orderDetailRepository,
        IUnitOfWork unitOfWork,
        ICreateOrderOutputPort outputPort,
        IEnumerable<IValidator<CreateOrderParams>> validators)
    {
        _orderRepository = orderRepository;
        _orderDetailRepository = orderDetailRepository;
        _unitOfWork = unitOfWork;
        _outputPort = outputPort;
        _validators = validators;
    }

    public async Task Handle(CreateOrderParams orderParam)
    {
        await Common.Validators.Validator<CreateOrderParams>.Validate(orderParam, _validators);

        Order order = new()
        {
            CustomerId = orderParam.CustomerId,
            OrderDate = DateTime.Now,
            ShipAddress = orderParam.ShipAddress,
            ShipCity = orderParam.ShipCity,
            ShipCountry = orderParam.ShipCountry,
            ShipPostalCode = orderParam.ShipPostalCode,
            ShippingType = Entities.Enums.ShippingType.Road,
            DiscountType = Entities.Enums.DiscountType.Percentage,
            Discount = 10
        };

        _orderRepository.Create(order);

        foreach (var item in orderParam.OrderDetails)
        {
            _orderDetailRepository.Create(new OrderDetail
            {
                Order = order,
                ProductId = item.ProductId,
                UnitPrice = item.UnitPrice,
                Quantity = item.Quantity
            });
        }

        try
        {
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new GeneralException("Error al crear la orden", ex.Message);
        }

        await _outputPort.Handle(order.Id);
    }
}