using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NorthWind.Repositories.EFCore.DataContext;

class NorthWindContextFactory : IDesignTimeDbContextFactory<NorthWindContext>
{
    public NorthWindContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<NorthWindContext>();
        optionBuilder.UseSqlServer("Server=.;database=NorthWindDB;Trusted_Connection=True;TrustServerCertificate=True");
        return new NorthWindContext(optionBuilder.Options);
    }
}