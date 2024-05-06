using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uppgift14_GarageV3.Migrations
{
    /// <inheritdoc />
    public partial class UnMapNumberOfWheelsProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfWheels",
                table: "ParkedVehicle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfWheels",
                table: "ParkedVehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
