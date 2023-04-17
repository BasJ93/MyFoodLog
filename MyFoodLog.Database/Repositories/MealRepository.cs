using MyFoodLog.Database.Models;
using MyFoodLog.Database.Repositories.Interfaces;

namespace MyFoodLog.Database.Repositories;

public class MealRepository : GenericCrudRepository<Meal>, IMealRepository
{
    public MealRepository(MyFoodLogDbContext dbContext) : base(dbContext)
    {
    }
}