using Microsoft.EntityFrameworkCore.Migrations;

namespace CrazyFood.DomainModel.Migrations
{
    public partial class UpdateUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_AspNetUsers_UserId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_UserId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ReviewLike");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ReviewComment");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Review");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ReviewLike",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ReviewComment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Review",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Review",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserId",
                table: "Review",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_AspNetUsers_UserId",
                table: "Review",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
