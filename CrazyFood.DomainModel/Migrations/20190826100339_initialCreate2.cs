using Microsoft.EntityFrameworkCore.Migrations;

namespace CrazyFood.DomainModel.Migrations
{
    public partial class initialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewComment_Review_ReviewId",
                table: "ReviewComment");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewLike_Review_ReviewId",
                table: "ReviewLike");

            migrationBuilder.DropIndex(
                name: "IX_ReviewLike_ReviewId",
                table: "ReviewLike");

            migrationBuilder.DropIndex(
                name: "IX_ReviewComment_ReviewId",
                table: "ReviewComment");

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Review",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Review");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewLike_ReviewId",
                table: "ReviewLike",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewComment_ReviewId",
                table: "ReviewComment",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewComment_Review_ReviewId",
                table: "ReviewComment",
                column: "ReviewId",
                principalTable: "Review",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewLike_Review_ReviewId",
                table: "ReviewLike",
                column: "ReviewId",
                principalTable: "Review",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
