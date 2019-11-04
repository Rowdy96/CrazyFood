using Microsoft.EntityFrameworkCore.Migrations;

namespace CrazyFood.DomainModel.Migrations
{
    public partial class UpdatedFollowTableagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "FollowingUserId",
                table: "Follow",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "FollowedUserId",
                table: "Follow",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Follow_FollowedUserId",
                table: "Follow",
                column: "FollowedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Follow_FollowingUserId",
                table: "Follow",
                column: "FollowingUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Follow_AspNetUsers_FollowedUserId",
                table: "Follow",
                column: "FollowedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Follow_AspNetUsers_FollowingUserId",
                table: "Follow",
                column: "FollowingUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follow_AspNetUsers_FollowedUserId",
                table: "Follow");

            migrationBuilder.DropForeignKey(
                name: "FK_Follow_AspNetUsers_FollowingUserId",
                table: "Follow");

            migrationBuilder.DropIndex(
                name: "IX_Follow_FollowedUserId",
                table: "Follow");

            migrationBuilder.DropIndex(
                name: "IX_Follow_FollowingUserId",
                table: "Follow");

            migrationBuilder.AlterColumn<int>(
                name: "FollowingUserId",
                table: "Follow",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FollowedUserId",
                table: "Follow",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FollowedUserId1",
                table: "Follow",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FollowingUserId1",
                table: "Follow",
                nullable: true);

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
    }
}
