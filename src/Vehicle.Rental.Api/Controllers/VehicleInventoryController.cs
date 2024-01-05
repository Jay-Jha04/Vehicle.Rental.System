using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using VehicleHub.Rental.Api.ViewModel;
using VehicleHub.Rental.DAL.Context;
using VehicleHub.Rental.DAL.Models;

namespace VehicleHub.Rental.Api.Controllers
{
    [ApiController]
    [Route("vehicle-inventory/{inventoryId}")]
    public class VehicleInventoryController : Controller
    {
        private readonly VehicleRentalDbContext _dbContext;
        private readonly IMapper _mapper;

        public VehicleInventoryController(VehicleRentalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetVehicles(int inventoryId)
        {
            var result = _dbContext.VehicleInventories
                .Where(vi => vi.Id == inventoryId)
                .Select(vi => vi.Vehicles).ToList();

            return Ok(result);
        }

        [HttpGet("{vehicleId:int}")]
        public IActionResult GetVehicle(int inventoryId, int vehicleId)
        {
            var result = _dbContext.Vehicles
                .FirstOrDefault(v => v.VehicleInventoryId == inventoryId && v.Id == vehicleId);

            return Ok(result);
        }

        [HttpGet("{vin}")]
        public IActionResult GetVehicleByVin(int inventoryId,string vin)
        {
            var result = _dbContext.Vehicles
                .Where(v => v.VehicleInventoryId == inventoryId && v.Vin == vin).ToList();
            if(result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddVehicle(int inventoryId, VehicleViewModel vehicle)
        {
            Vehicle vehicleDTO = _mapper.Map<Vehicle>(vehicle);
            _dbContext.Vehicles.Add(vehicleDTO);

            _dbContext.SaveChanges();
            return Ok(vehicleDTO.Id);
        }

        [HttpDelete("{vehicleId}")]
        public IActionResult DeleteVehicle(int vehicleId)
        {

            var vehicle = _dbContext.Vehicles
                .FirstOrDefault(vi => vi.Id == vehicleId);
            if(vehicle == null)
            {
                return NotFound();
            }
            _dbContext.Vehicles.Remove(vehicle);
            _dbContext.SaveChanges();

            return Ok(vehicle.Id);
        }
    }
}
