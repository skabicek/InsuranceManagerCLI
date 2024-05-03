using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FincoraConsoleAppDemo.Migrations
{
    /// <inheritdoc />
    public partial class addingAtribs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Addresss_AddressID",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceCompanies_Addresss_AddressId",
                table: "InsuranceCompanies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresss",
                table: "Addresss");

            migrationBuilder.RenameTable(
                name: "Addresss",
                newName: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "InvolveVehicle",
                table: "ContractTypes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Addresses_AddressID",
                table: "Clients",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceCompanies_Addresses_AddressId",
                table: "InsuranceCompanies",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Addresses_AddressID",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceCompanies_Addresses_AddressId",
                table: "InsuranceCompanies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "InvolveVehicle",
                table: "ContractTypes");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Addresss");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresss",
                table: "Addresss",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Addresss_AddressID",
                table: "Clients",
                column: "AddressID",
                principalTable: "Addresss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceCompanies_Addresss_AddressId",
                table: "InsuranceCompanies",
                column: "AddressId",
                principalTable: "Addresss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
