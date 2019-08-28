using Microsoft.EntityFrameworkCore.Migrations;

namespace CrazyFood.DomainModel.Migrations
{
    public partial class UpdateReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_UserId1",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_AspNetUsers_UserId1",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewComment_AspNetUsers_UserId1",
                table: "ReviewComment");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewLike_AspNetUsers_UserId1",
                table: "ReviewLike");

            migrationBuilder.DropIndex(
                name: "IX_ReviewLike_UserId1",
                table: "ReviewLike");

            migrationBuilder.DropIndex(
                name: "IX_ReviewComment_UserId1",
                table: "ReviewComment");

            migrationBuilder.DropIndex(
                name: "IX_Review_UserId1",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Order_UserId1",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ReviewLike");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ReviewComment");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Order");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ReviewLike",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ReviewComment",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Review",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Order",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_ReviewLike_UserId",
                table: "ReviewLike",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewComment_UserId",
                table: "ReviewComment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserId",
                table: "Review",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_UserId",
                table: "Order",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_AspNetUsers_UserId",
                table: "Review",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewComment_AspNetUsers_UserId",
                table: "ReviewComment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewLike_AspNetUsers_UserId",
                table: "ReviewLike",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_UserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_AspNetUsers_UserId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewComment_AspNetUsers_UserId",
                table: "ReviewComment");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewLike_AspNetUsers_UserId",
                table: "ReviewLike");

            migrationBuilder.DropIndex(
                name: "IX_ReviewLike_UserId",
                table: "ReviewLike");

            migrationBuilder.DropIndex(
                name: "IX_ReviewComment_UserId",
                table: "ReviewComment");

            migrationBuilder.DropIndex(
                name: "IX_Review_UserId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Order_UserId",
                table: "Order");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ReviewLike",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "ReviewLike",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ReviewComment",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "ReviewComment",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Review",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Review",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Order",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Order",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReviewLike_UserId1",
                table: "ReviewLike",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewComment_UserId1",
                table: "ReviewComment",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserId1",
                table: "Review",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId1",
                table: "Order",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_UserId1",
                table: "Order",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_AspNetUsers_UserId1",
                table: "Review",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewComment_AspNetUsers_UserId1",
                table: "ReviewComment",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewLike_AspNetUsers_UserId1",
                table: "ReviewLike",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
