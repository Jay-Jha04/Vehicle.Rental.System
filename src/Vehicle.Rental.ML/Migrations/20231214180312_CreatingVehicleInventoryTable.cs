using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleHub.Rental.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CreatingVehicleInventoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehicleInventoryId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "VehicleInventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleInventories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleInventoryId",
                table: "Vehicles",
                column: "VehicleInventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleInventories_VehicleInventoryId",
                table: "Vehicles",
                column: "VehicleInventoryId",
                principalTable: "VehicleInventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleInventories_VehicleInventoryId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "VehicleInventories");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VehicleInventoryId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleInventoryId",
                table: "Vehicles");
        }
    }
}
