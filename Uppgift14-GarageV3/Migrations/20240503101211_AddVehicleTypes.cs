using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uppgift14_GarageV3.Migrations
{
    /// <inheritdoc />
    public partial class AddVehicleTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VehicleType",
                table: "ParkedVehicle",
                newName: "VehicleTypeID");

            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNumber",
                table: "ParkedVehicle",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumSpacesNeededToPark = table.Column<int>(type: "int", nullable: false),
                    NumberOfWheels = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkedVehicle_VehicleTypeID",
                table: "ParkedVehicle",
                column: "VehicleTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkedVehicle_VehicleType_VehicleTypeID",
                table: "ParkedVehicle",
                column: "VehicleTypeID",
                principalTable: "VehicleType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkedVehicle_VehicleType_VehicleTypeID",
                table: "ParkedVehicle");

            migrationBuilder.DropTable(
                name: "VehicleType");

            migrationBuilder.DropIndex(
                name: "IX_ParkedVehicle_VehicleTypeID",
                table: "ParkedVehicle");

            migrationBuilder.RenameColumn(
                name: "VehicleTypeID",
                table: "ParkedVehicle",
                newName: "VehicleType");

            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNumber",
                table: "ParkedVehicle",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);
        }
    }
}
