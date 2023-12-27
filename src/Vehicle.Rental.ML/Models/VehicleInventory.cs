using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleHub.Rental.DAL.Models
{
    [Table("VehicleInventories")]
    public class VehicleInventory
    {
        public int Id { get; set; }
        
        public ICollection<Vehicle> Vehicles { get; set; }

        public VehicleInventory()
        {
            Vehicles = new Collection<Vehicle>();
        }
    }
}
