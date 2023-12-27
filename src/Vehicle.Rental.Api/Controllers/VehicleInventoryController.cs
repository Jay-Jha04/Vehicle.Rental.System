using Microsoft.AspNetCore.Mvc;
using VehicleHub.Rental.DAL.Context;

namespace VehicleHub.Rental.Api.Controllers
{
    [ApiController]
    [Route("vehicle-inventory/{inventoryId}")]
    public class VehicleInventoryController : Controller
    {
        private readonly VehicleRentalDbContext _dbContext;

        public VehicleInventoryController(VehicleRentalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetVehicles(int inventoryId)
        {
            var result = _dbContext.VehicleInventories
                .Where(vi => vi.Id == inventoryId)
                .Select(vi => vi.Vehicles).ToList();

            return Ok(result);
        }

        [HttpGet("{vehicleId}")]
        public IActionResult GetVehicle(int inventoryId, int vehicleId)
        {
            var result = _dbContext.Vehicles
                .FirstOrDefault(v => v.VehicleInventoryId == inventoryId && v.Id == vehicleId);

            return Ok(result);
        }
    }
}
