using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoachApp.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class addclientservices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress_StreetNumber",
                table: "Clients",
                newName: "Address_StreetNumber");

            migrationBuilder.RenameColumn(
                name: "Adress_Street",
                table: "Clients",
                newName: "Address_Street");

            migrationBuilder.RenameColumn(
                name: "Adress_PostalCode",
                table: "Clients",
                newName: "Address_PostalCode");

            migrationBuilder.RenameColumn(
                name: "Adress_Complement",
                table: "Clients",
                newName: "Address_Complement");

            migrationBuilder.RenameColumn(
                name: "Adress_City",
                table: "Clients",
                newName: "Address_City");

            migrationBuilder.RenameColumn(
                name: "Adress_AdditionalInformation",
                table: "Clients",
                newName: "Address_AdditionalInformation");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price_Amount",
                table: "Packs",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "ClientService",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price_Amount = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    Price_Currency = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientService", x => new { x.ClientId, x.Id });
                    table.ForeignKey(
                        name: "FK_ClientService_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientService");

            migrationBuilder.RenameColumn(
                name: "Address_StreetNumber",
                table: "Clients",
                newName: "Adress_StreetNumber");

            migrationBuilder.RenameColumn(
                name: "Address_Street",
                table: "Clients",
                newName: "Adress_Street");

            migrationBuilder.RenameColumn(
                name: "Address_PostalCode",
                table: "Clients",
                newName: "Adress_PostalCode");

            migrationBuilder.RenameColumn(
                name: "Address_Complement",
                table: "Clients",
                newName: "Adress_Complement");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "Clients",
                newName: "Adress_City");

            migrationBuilder.RenameColumn(
                name: "Address_AdditionalInformation",
                table: "Clients",
                newName: "Adress_AdditionalInformation");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price_Amount",
                table: "Packs",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldPrecision: 5,
                oldScale: 2);
        }
    }
}
