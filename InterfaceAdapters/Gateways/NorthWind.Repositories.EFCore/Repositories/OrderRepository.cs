using NorthWind.Entities.Interfaces;
using NorthWind.Entities.POCOEntities;
using NorthWind.Entities.Specifications;
using NorthWind.Repositories.EFCore.DataContext;

namespace NorthWind.Repositories.EFCore.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly NorthWindContext _context;

    public OrderRepository(NorthWindContext context)
    {
        _context = context;
    }

    public void Create(Order order)
    {
        _context.Add(order);
    }

    public IEnumerable<Order> GetOrdersBySpecification(Specification<Order> specification)
    {
        var expressionDelegate = specification.Expression.Compile();
        return _context.Orders.Where(expressionDelegate);
    }
}