using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFoodLog.Database.Models;

namespace MyFoodLog.Database.Configuration;

public class MealTypeConfiguration : IEntityTypeConfiguration<MealType>
{
    public void Configure(EntityTypeBuilder<MealType> builder)
    {
        builder.Property(b => b.Id)
            .IsRequired();

        builder.Property(b => b.Name)
            .IsUnicode()
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(b => b.StartTime)
            .IsRequired(false);
        
        builder.Property(b => b.EndTime)
            .IsRequired(false);
    }
}