using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class t : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accountTypes",
                columns: table => new
                {
                    accountTypeID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accountTypes", x => x.accountTypeID);
                });

            migrationBuilder.CreateTable(
                name: "etablishmentType",
                columns: table => new
                {
                    etablishmentTypeID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etablishmentType", x => x.etablishmentTypeID);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    userID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    accountTypeID = table.Column<int>(nullable: false),
                    Login = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.userID);
                    table.ForeignKey(
                        name: "FK_user_accountTypes_accountTypeID",
                        column: x => x.accountTypeID,
                        principalTable: "accountTypes",
                        principalColumn: "accountTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "etablishment",
                columns: table => new
                {
                    etablishmentID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    street = table.Column<string>(nullable: false),
                    postalcode = table.Column<string>(nullable: false),
                    phonenumber = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    average = table.Column<int>(nullable: false),
                    etablishmenttypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etablishment", x => x.etablishmentID);
                    table.ForeignKey(
                        name: "FK_etablishment_etablishmentType_etablishmenttypeID",
                        column: x => x.etablishmenttypeID,
                        principalTable: "etablishmentType",
                        principalColumn: "etablishmentTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chamber",
                columns: table => new
                {
                    chamberID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    etablishmentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chamber", x => x.chamberID);
                    table.ForeignKey(
                        name: "FK_chamber_etablishment_etablishmentID",
                        column: x => x.etablishmentID,
                        principalTable: "etablishment",
                        principalColumn: "etablishmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    rating = table.Column<int>(nullable: false),
                    comment = table.Column<string>(nullable: true),
                    userID = table.Column<int>(nullable: false),
                    etablishmentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => new { x.etablishmentID, x.userID });
                    table.ForeignKey(
                        name: "FK_comment_etablishment_etablishmentID",
                        column: x => x.etablishmentID,
                        principalTable: "etablishment",
                        principalColumn: "etablishmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comment_user_userID",
                        column: x => x.userID,
                        principalTable: "user",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userEtablishment",
                columns: table => new
                {
                    etablishmentID = table.Column<int>(nullable: false),
                    userID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userEtablishment", x => new { x.etablishmentID, x.userID });
                    table.ForeignKey(
                        name: "FK_userEtablishment_etablishment_etablishmentID",
                        column: x => x.etablishmentID,
                        principalTable: "etablishment",
                        principalColumn: "etablishmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userEtablishment_user_userID",
                        column: x => x.userID,
                        principalTable: "user",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chamber_etablishmentID",
                table: "chamber",
                column: "etablishmentID");

            migrationBuilder.CreateIndex(
                name: "IX_comment_userID",
                table: "comment",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_etablishment_etablishmenttypeID",
                table: "etablishment",
                column: "etablishmenttypeID");

            migrationBuilder.CreateIndex(
                name: "IX_user_accountTypeID",
                table: "user",
                column: "accountTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_userEtablishment_etablishmentID",
                table: "userEtablishment",
                column: "etablishmentID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userEtablishment_userID",
                table: "userEtablishment",
                column: "userID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chamber");

            migrationBuilder.DropTable(
                name: "comment");

            migrationBuilder.DropTable(
                name: "userEtablishment");

            migrationBuilder.DropTable(
                name: "etablishment");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "etablishmentType");

            migrationBuilder.DropTable(
                name: "accountTypes");
        }
    }
}
