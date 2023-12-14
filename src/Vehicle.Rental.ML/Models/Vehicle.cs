using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleHub.Rental.DAL.Models
{
    [Table("Vehicles")]
    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        [Range(1000, 9999)]
        public int Year { get; set; }

        [Required]
        public string Vin { get; set; }

        [Required]
        [Range(2, 10)]
        public byte NoOfSeats { get; set; }

        public GasType GasType { get; set; }
        
        public bool IsFastrack { get; set; }
    }
}
