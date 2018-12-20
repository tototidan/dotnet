using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class tt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "nbChamber",
                table: "etablishment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    reservationID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    arrive = table.Column<DateTime>(nullable: false),
                    depart = table.Column<DateTime>(nullable: false),
                    chamberID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.reservationID);
                    table.ForeignKey(
                        name: "FK_Reservation_chamber_chamberID",
                        column: x => x.chamberID,
                        principalTable: "chamber",
                        principalColumn: "chamberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_chamberID",
                table: "Reservation",
                column: "chamberID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropColumn(
                name: "nbChamber",
                table: "etablishment");
        }
    }
}
