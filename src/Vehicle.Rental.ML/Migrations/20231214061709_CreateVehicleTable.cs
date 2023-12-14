using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleHub.Rental.DAL.Migrations;

/// <inheritdoc />
public partial class CreateVehicleTable : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Vehicles",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Year = table.Column<int>(type: "int", nullable: false),
                Vin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                NoOfSeats = table.Column<byte>(type: "tinyint", nullable: false),
                GasType = table.Column<int>(type: "int", nullable: false),
                IsFastrack = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Vehicles", x => x.Id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Vehicles");
    }
}
