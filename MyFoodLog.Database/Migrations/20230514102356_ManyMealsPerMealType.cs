using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFoodLog.Database.Migrations
{
    public partial class ManyMealsPerMealType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Meals_MealTypeId",
                table: "Meals");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MealTypeId",
                table: "Meals",
                column: "MealTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Meals_MealTypeId",
                table: "Meals");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MealTypeId",
                table: "Meals",
                column: "MealTypeId",
                unique: true);
        }
    }
}
