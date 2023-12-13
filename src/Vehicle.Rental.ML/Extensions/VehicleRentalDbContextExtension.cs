using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vehicle.Rental.DAL.Context;

namespace Vehicle.Rental.DAL.Extensions
{
    public static class VehicleRentalDbContextExtension
    {
        public static IServiceCollection AddVehicleRentalContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<VehicleRentalDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"));
            
            });
        }
    }
}
