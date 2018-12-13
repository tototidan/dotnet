using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class CreationModel : Migration
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
                name: "comment",
                columns: table => new
                {
                    commentID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.commentID);
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
                    accountTypeID = table.Column<int>(nullable: false)
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
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    street = table.Column<string>(nullable: true),
                    postalcode = table.Column<string>(nullable: true),
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
                name: "rating",
                columns: table => new
                {
                    userID = table.Column<int>(nullable: false),
                    etablishmentID = table.Column<int>(nullable: false),
                    rating = table.Column<int>(nullable: false),
                    commentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rating", x => new { x.etablishmentID, x.userID });
                    table.ForeignKey(
                        name: "FK_rating_comment_commentID",
                        column: x => x.commentID,
                        principalTable: "comment",
                        principalColumn: "commentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rating_etablishment_etablishmentID",
                        column: x => x.etablishmentID,
                        principalTable: "etablishment",
                        principalColumn: "etablishmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rating_user_userID",
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
                name: "IX_etablishment_etablishmenttypeID",
                table: "etablishment",
                column: "etablishmenttypeID");

            migrationBuilder.CreateIndex(
                name: "IX_rating_commentID",
                table: "rating",
                column: "commentID");

            migrationBuilder.CreateIndex(
                name: "IX_rating_userID",
                table: "rating",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_user_accountTypeID",
                table: "user",
                column: "accountTypeID");

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
                name: "rating");

            migrationBuilder.DropTable(
                name: "userEtablishment");

            migrationBuilder.DropTable(
                name: "comment");

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
