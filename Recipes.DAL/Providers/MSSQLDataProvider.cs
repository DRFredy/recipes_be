using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Recipes.DAL.Configuration;

namespace Recipes.DAL.Providers
{
  public class MSSQLDataProvider : IDataProvider
  {
    public DataProvider Provider { get; } = DataProvider.MSSQL;

    public IServiceCollection RegisterDbContext(IServiceCollection services, string connectionString)
    {
      services.AddDbContext<AppDbContext>(options =>
          options.UseSqlServer(connectionString));

      return services;
    }

    public AppDbContext CreateDbContext(string connectionString)
    {    
      var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
      optionsBuilder.UseSqlServer(connectionString);
      
      return new AppDbContext(optionsBuilder.Options);
    }
  }
}