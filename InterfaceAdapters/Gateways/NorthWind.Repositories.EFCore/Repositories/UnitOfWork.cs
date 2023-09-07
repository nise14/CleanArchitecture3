using NorthWind.Entities.Interfaces;
using NorthWind.Repositories.EFCore.DataContext;

namespace NorthWind.Repositories.EFCore.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly NorthWindContext _context;

    public UnitOfWork(NorthWindContext context)
    {
        _context = context;
    }

    public Task<int> SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}