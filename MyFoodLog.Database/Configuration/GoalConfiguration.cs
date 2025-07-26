using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFoodLog.Database.Models;

namespace MyFoodLog.Database.Configuration;

public class GoalConfiguration : IEntityTypeConfiguration<Goal>
{
    public void Configure(EntityTypeBuilder<Goal> builder)
    {
        builder.Property(x => x.Id)
            .IsRequired();

        builder.Property(x => x.Energy)
            .IsRequired();
        
        builder.Property(x => x.Fat)
            .IsRequired(false);
        
        builder.Property(x => x.Carbohydrates)
            .IsRequired(false);
        
        builder.Property(x => x.Protein)
            .IsRequired(false);
    }
}