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
                    Adress_AdditionalInformation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
