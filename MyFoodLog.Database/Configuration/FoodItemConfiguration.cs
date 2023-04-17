using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFoodLog.Database.Models;

namespace MyFoodLog.Database.Configuration;

public class FoodItemConfiguration : IEntityTypeConfiguration<FoodItem>
{
    public void Configure(EntityTypeBuilder<FoodItem> builder)
    {
        builder.ToTable("FoodItems");

        builder.HasKey(b => b.Id)
            .HasName($"PK_FoodItems");
        
        builder.Property(b => b.Id)
            .IsRequired();

        builder.Property(b => b.Name)
            .HasMaxLength(300)
            .IsUnicode()
            .IsRequired();

        builder.Property(b => b.EAN13)
            .IsRequired(false);
        
        builder.Property(b => b.Energy)
            .HasPrecision(4) //Set to 4 decimals
            .IsRequired();
        
        builder.Property(b => b.Carbohydrates)
            .HasPrecision(4) //Set to 4 decimals
            .IsRequired();
        
        builder.Property(b => b.Fat)
            .HasPrecision(4) //Set to 4 decimals
            .IsRequired();
        
        builder.Property(b => b.Protein)
            .HasPrecision(4) //Set to 4 decimals
            .IsRequired();
    }
}