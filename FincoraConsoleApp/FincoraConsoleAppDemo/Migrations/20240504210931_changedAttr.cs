using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FincoraConsoleAppDemo.Migrations
{
    /// <inheritdoc />
    public partial class changedAttr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfSeats",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Degree",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "GearboxType",
                table: "Vehicles",
                newName: "YearOfManufacture");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "YearOfManufacture",
                table: "Vehicles",
                newName: "GearboxType");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfSeats",
                table: "Vehicles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Degree",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
