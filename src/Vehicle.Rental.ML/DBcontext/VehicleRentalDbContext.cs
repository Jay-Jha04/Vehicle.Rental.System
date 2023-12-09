using Microsoft.EntityFrameworkCore;

namespace Vehicle.Rental.DataStorage.DBcontext
{
    public class VehicleRentalDbContext : DbContext
    {
        public VehicleRentalDbContext(DbContextOptions<VehicleRentalDbContext> options) : base(options) 
        {
        }
    }
}
