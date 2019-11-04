using Microsoft.EntityFrameworkCore.Migrations;

namespace CrazyFood.DomainModel.Migrations
{
    public partial class UpdatedFollowTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FollowedUserId1",
                table: "Follow",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FollowingUserId1",
                table: "Follow",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFollowed",
                table: "Follow",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Follow_FollowedUserId1",
                table: "Follow",
                column: "FollowedUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Follow_FollowingUserId1",
                table: "Follow",
                column: "FollowingUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Follow_AspNetUsers_FollowedUserId1",
                table: "Follow",
                column: "FollowedUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Follow_AspNetUsers_FollowingUserId1",
                table: "Follow",
                column: "FollowingUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follow_AspNetUsers_FollowedUserId1",
                table: "Follow");

            migrationBuilder.DropForeignKey(
                name: "FK_Follow_AspNetUsers_FollowingUserId1",
                table: "Follow");

            migrationBuilder.DropIndex(
                name: "IX_Follow_FollowedUserId1",
                table: "Follow");

            migrationBuilder.DropIndex(
                name: "IX_Follow_FollowingUserId1",
                table: "Follow");

            migrationBuilder.DropColumn(
                name: "FollowedUserId1",
                table: "Follow");

            migrationBuilder.DropColumn(
                name: "FollowingUserId1",
                table: "Follow");

            migrationBuilder.DropColumn(
                name: "IsFollowed",
                table: "Follow");
        }
    }
}
