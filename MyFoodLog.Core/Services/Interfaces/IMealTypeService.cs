using MyFoodLog.Models.MealTypes;

namespace MyFoodLog.Core.Services.Interfaces;

public interface IMealTypeService
{
    Task<IEnumerable<MealTypeDto>> GetAll(CancellationToken ctx);
}