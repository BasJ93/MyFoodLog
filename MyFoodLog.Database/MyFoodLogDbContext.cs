using Microsoft.EntityFrameworkCore;
using MyFoodLog.Database.Configuration;
using MyFoodLog.Database.Models;

namespace MyFoodLog.Database;

public sealed class MyFoodLogDbContext : DbContext
{
    public DbSet<FoodItem>? FoodItems { get; set; }

    public DbSet<FoodItemConsumption>? FoodConsumption { get; set; }

    public DbSet<Meal>? Meals { get; set; }

    public DbSet<MealType>? MealTypes { get; set; }

    public MyFoodLogDbContext()
    {
        
    }
    
    public MyFoodLogDbContext(DbContextOptions<MyFoodLogDbContext> options) : base(options)
    {
        //Database.EnsureCreated();
        if (Database.GetPendingMigrations().Any())
        {
            Database.Migrate();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FoodItemConfiguration).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=MyFoodLog.db");
        base.OnConfiguring(optionsBuilder);
    }
}