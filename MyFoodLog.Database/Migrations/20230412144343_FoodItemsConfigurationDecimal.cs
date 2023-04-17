using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFoodLog.Database.Migrations
{
    /// <inheritdoc />
    public partial class FoodItemsConfigurationDecimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Energy",
                table: "FoodItems",
                type: "TEXT",
                precision: 4,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL",
                oldPrecision: 4);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Energy",
                table: "FoodItems",
                type: "REAL",
                precision: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldPrecision: 4);
        }
    }
}
