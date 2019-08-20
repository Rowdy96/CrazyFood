using Microsoft.EntityFrameworkCore.Migrations;

namespace CrazyFood.DomainModel.Migrations
{
    public partial class updatedFollowTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follows_Users_userId",
                table: "Follows");

            migrationBuilder.DropIndex(
                name: "IX_Follows_userId",
                table: "Follows");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Follows");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Follows",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Follows_userId",
                table: "Follows",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_Users_userId",
                table: "Follows",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
