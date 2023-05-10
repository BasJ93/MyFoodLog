using MyFoodLog.Database.Models;
using MyFoodLog.Database.Repositories.Interfaces;

namespace MyFoodLog.Database.Repositories;

public class MealTypeRepository : GenericCrudRepository<MealType>, IMealTypeRepository
{
    public MealTypeRepository(MyFoodLogDbContext dbContext) : base(dbContext)
    {
    }
}