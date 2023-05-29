using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoachApp.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class renameuserproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "EncrytedPassword");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "Users",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EncrytedPassword",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "Login");
        }
    }
}
