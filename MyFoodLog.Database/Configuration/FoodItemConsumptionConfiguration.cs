using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFoodLog.Database.Models;

namespace MyFoodLog.Database.Configuration;

public class FoodItemConsumptionConfiguration : IEntityTypeConfiguration<FoodItemConsumption>
{
    public void Configure(EntityTypeBuilder<FoodItemConsumption> builder)
    {
        builder.Property(b => b.Id)
            .IsRequired();

        builder.Property(b => b.Amount)
            .HasPrecision(2) // 2 decimals
            .IsRequired();

        builder.Property(b => b.MealId)
            .IsRequired();
        
        builder.Property(b => b.FoodItemId)
            .IsRequired();

        builder.HasOne(b => b.Meal)
            .WithMany(m => m.ConsumedItems)
            .HasForeignKey(f => f.MealId)
            .HasConstraintName($"FK_{nameof(Meal)}_{nameof(FoodItemConsumption)}");

        builder.HasOne(b => b.FoodItem)
            .WithMany()
            .HasForeignKey(f => f.FoodItemId)
            .HasConstraintName($"FK_{nameof(FoodItemConsumption)}_{nameof(FoodItem)}");

    }
}