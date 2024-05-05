using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FincoraConsoleAppDemo.Migrations
{
    /// <inheritdoc />
    public partial class addindDateContract : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<char>(
                name: "InvolveVehicle",
                table: "ContractTypes",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<DateOnly>(
                name: "SignDate",
                table: "Contracts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(2024, 5, 5));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SignDate",
                table: "Contracts");

            migrationBuilder.AlterColumn<int>(
                name: "InvolveVehicle",
                table: "ContractTypes",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(char),
                oldType: "TEXT");
        }
    }
}
