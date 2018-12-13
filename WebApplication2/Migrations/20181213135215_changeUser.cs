using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class changeUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "user",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "user",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                table: "user");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "user");
        }
    }
}
