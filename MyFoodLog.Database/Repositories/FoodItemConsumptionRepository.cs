using MyFoodLog.Database.Models;
using MyFoodLog.Database.Repositories.Interfaces;

namespace MyFoodLog.Database.Repositories;

public class FoodItemConsumptionRepository : GenericCrudRepository<FoodItemConsumption>, IFoodItemConsumptionRepository
{
    public FoodItemConsumptionRepository(MyFoodLogDbContext dbContext) : base(dbContext)
    {
    }
}