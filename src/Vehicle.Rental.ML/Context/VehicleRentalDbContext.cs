using Microsoft.EntityFrameworkCore;
using VehicleHub.Rental.DAL.Models;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleType>()
                .Property(v => v.GasType)
                .HasConversion(
                    gasType => gasType.ToString(),
                    gasType => (GasType)Enum.Parse(typeof(GasType), gasType)
                );
        }
    }
}
