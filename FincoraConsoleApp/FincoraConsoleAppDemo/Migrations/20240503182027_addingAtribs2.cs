using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FincoraConsoleAppDemo.Migrations
{
    /// <inheritdoc />
    public partial class addingAtribs2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Contracts",
                type: "TEXT",
                nullable: false,
                defaultValue: "Active",
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Contracts",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldDefaultValue: "Active");
        }
    }
}
