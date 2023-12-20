using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using VehicleHub.Rental.DAL.Models;

namespace VehicleHub.Rental.DAL.Context
{
    public class VehicleRentalDbContext : DbContext
    {
        public VehicleRentalDbContext(DbContextOptions<VehicleRentalDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleInventory> VehicleInventories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .Property(v => v.GasType)
                .HasConversion(
                    gasType => gasType.ToString(),
                    gasType => (GasType)Enum.Parse(typeof(GasType), gasType)
                );

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.VehicleInventory)
                .WithMany(vi => vi.Vehicles)
                .HasForeignKey(v => v.VehicleInventoryId);
        }
    }
}
