using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleHub.Rental.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedingTestVehicleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Seed data for VehicleInventories table
            migrationBuilder.Sql(@"INSERT INTO VehicleInventories DEFAULT VALUES; ");

            // Seed data for Vehicles table
            var query = @"INSERT INTO Vehicles (Make, Model, Year, Vin, NoOfSeats, GasType, IsFastrack, VehicleInventoryId) VALUES
                  ('Toyota', 'Camry', 2022, 'ABC123456789', 5, 'Petrol', 1, SCOPE_IDENTITY()),
                  ('Honda', 'Civic', 2021, 'XYZ987654321', 4, 'CNG', 0, SCOPE_IDENTITY()),
                  ('Ford', 'Mustang', 2023, 'DEF456789012', 2, 'Diesel', 1, SCOPE_IDENTITY()),
                  ('Chevrolet', 'Tahoe', 2022, 'GHI345678901', 7, 'Petrol', 0, SCOPE_IDENTITY()),
                  ('Nissan', 'Altima', 2020, 'JKL567890123', 5, 'Petrol', 0, SCOPE_IDENTITY()),
                  ('Tesla', 'Model S', 2023, 'MNO789012345', 4, 'Electric', 1, SCOPE_IDENTITY()),
                  ('BMW', 'X5', 2021, 'PQR901234567', 5, 'Diesel', 0, SCOPE_IDENTITY()),
                  ('Audi', 'A4', 2022, 'STU123456789', 5, 'Petrol', 1, SCOPE_IDENTITY()),
                  ('Hyundai', 'Santa Fe', 2023, 'VWX234567890', 6, 'CNG', 0, SCOPE_IDENTITY()),
                  ('Mercedes-Benz', 'C-Class', 2020, 'YZA345678901', 4, 'Petrol', 1, SCOPE_IDENTITY());";

            migrationBuilder.Sql(query);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM VehicleInventories");

            var query = @"DELETE FROM Vehicles WHERE 
                   Vin IN ('ABC123456789', 'XYZ987654321', 'DEF456789012', 
                           'GHI345678901', 'JKL567890123', 'MNO789012345', 
                           'PQR901234567', 'STU123456789', 'VWX234567890', 
                           'YZA345678901');";

            migrationBuilder.Sql(query);
        }
    }
}
