using System.ComponentModel.DataAnnotations;
using VehicleHub.Rental.DAL.Models;

namespace VehicleHub.Rental.Api.ViewModel
{
    public class VehicleViewModel
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string Vin { get; set; }

        public byte NoOfSeats { get; set; }

        public GasType GasType { get; set; }

        public bool IsFastrack { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int VehicleInventoryId { get; set; }

    }
}
