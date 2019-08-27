using Microsoft.EntityFrameworkCore.Migrations;

namespace CrazyFood.DomainModel.Migrations
{
    public partial class updateMenuCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MenuCategory_RestaurantId",
                table: "MenuCategory",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuCategory_Restaurant_RestaurantId",
                table: "MenuCategory",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuCategory_Restaurant_RestaurantId",
                table: "MenuCategory");

            migrationBuilder.DropIndex(
                name: "IX_MenuCategory_RestaurantId",
                table: "MenuCategory");
        }
    }
}
