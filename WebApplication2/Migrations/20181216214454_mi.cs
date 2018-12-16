using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class mi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comment",
                table: "comment");

            migrationBuilder.AlterColumn<string>(
                name: "street",
                table: "etablishment",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "postalcode",
                table: "etablishment",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "etablishment",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "etablishment",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "commentID",
                table: "comment",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "etablishmentID",
                table: "comment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "userID",
                table: "comment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "rating",
                table: "comment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_comment",
                table: "comment",
                columns: new[] { "etablishmentID", "userID" });

            migrationBuilder.CreateIndex(
                name: "IX_userEtablishment_etablishmentID",
                table: "userEtablishment",
                column: "etablishmentID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_comment_userID",
                table: "comment",
                column: "userID");

            migrationBuilder.AddForeignKey(
                name: "FK_comment_etablishment_etablishmentID",
                table: "comment",
                column: "etablishmentID",
                principalTable: "etablishment",
                principalColumn: "etablishmentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comment_user_userID",
                table: "comment",
                column: "userID",
                principalTable: "user",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comment_etablishment_etablishmentID",
                table: "comment");

            migrationBuilder.DropForeignKey(
                name: "FK_comment_user_userID",
                table: "comment");

            migrationBuilder.DropIndex(
                name: "IX_userEtablishment_etablishmentID",
                table: "userEtablishment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comment",
                table: "comment");

            migrationBuilder.DropIndex(
                name: "IX_comment_userID",
                table: "comment");

            migrationBuilder.DropColumn(
                name: "etablishmentID",
                table: "comment");

            migrationBuilder.DropColumn(
                name: "userID",
                table: "comment");

            migrationBuilder.DropColumn(
                name: "rating",
                table: "comment");

            migrationBuilder.AlterColumn<string>(
                name: "street",
                table: "etablishment",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "postalcode",
                table: "etablishment",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "etablishment",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "etablishment",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "commentID",
                table: "comment",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_comment",
                table: "comment",
                column: "commentID");

            migrationBuilder.CreateTable(
                name: "rating",
                columns: table => new
                {
                    etablishmentID = table.Column<int>(nullable: false),
                    userID = table.Column<int>(nullable: false),
                    commentID = table.Column<int>(nullable: false),
                    rating = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_rating_commentID",
                table: "rating",
                column: "commentID");

            migrationBuilder.CreateIndex(
                name: "IX_rating_userID",
                table: "rating",
                column: "userID");
        }
    }
}
