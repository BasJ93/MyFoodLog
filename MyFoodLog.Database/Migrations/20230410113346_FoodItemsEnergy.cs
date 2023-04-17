using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFoodLog.Database.Migrations
{
    /// <inheritdoc />
    public partial class FoodItemsEnergy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Energy",
                table: "FoodItems",
                type: "REAL",
                precision: 2,
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Energy",
                table: "FoodItems");
        }
    }
}
