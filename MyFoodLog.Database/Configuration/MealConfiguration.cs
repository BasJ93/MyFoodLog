using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFoodLog.Database.Models;

namespace MyFoodLog.Database.Configuration;

public class MealConfiguration : IEntityTypeConfiguration<Meal>
{
    public void Configure(EntityTypeBuilder<Meal> builder)
    {
        builder.Property(b => b.Id)
            .IsRequired();

        builder.Property(b => b.MealTypeId)
            .IsRequired();

        builder.HasOne(b => b.MealType)
            .WithMany()
            .HasForeignKey(m => m.MealTypeId)
            .HasConstraintName($"FK_{nameof(Meal)}_{nameof(MealType)}");
    }
}