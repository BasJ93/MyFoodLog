using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFoodLog.Database.Migrations
{
    public partial class FoodItemsManyConsumptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FoodConsumption_FoodItemId",
                table: "FoodConsumption");

            migrationBuilder.CreateIndex(
                name: "IX_FoodConsumption_FoodItemId",
                table: "FoodConsumption",
                column: "FoodItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FoodConsumption_FoodItemId",
                table: "FoodConsumption");

            migrationBuilder.CreateIndex(
                name: "IX_FoodConsumption_FoodItemId",
                table: "FoodConsumption",
                column: "FoodItemId",
                unique: true);
        }
    }
}
