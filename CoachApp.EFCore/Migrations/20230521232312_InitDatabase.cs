using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoachApp.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContactDetails_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactDetails_Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress_StreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress_Complement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress_AdditionalInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPersonalServices = table.Column<bool>(type: "bit", nullable: false),
                    OwnerUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContactDetails_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactDetails_Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyInformation_StreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyInformation_Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyInformation_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyInformation_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyInformation_SiretNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyInformation_SAPAgreementNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyInformation_Activity = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price_Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfSessions = table.Column<int>(type: "int", nullable: false),
                    RemainingSessions = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packs", x => new { x.ClientId, x.Id });
                    table.ForeignKey(
                        name: "FK_Packs_Clients_ClientId",
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
                name: "Packs");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
