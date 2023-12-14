using Microsoft.EntityFrameworkCore;
using VehicleType = VehicleHub.Rental.DAL.Models.Vehicle;

namespace VehicleHub.Rental.DAL.Context
{
    public class VehicleRentalDbContext : DbContext
    {
        public VehicleRentalDbContext(DbContextOptions<VehicleRentalDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<VehicleType> Vehicles { get; set; } 
    }
}
