using MyFoodLog.Models.MealTypes;

namespace MyFoodLog.Core.Services.Interfaces;

public interface IMealTypeService
{
    Task<IEnumerable<MealTypeDto>> GetAll(CancellationToken ctx = default);

    Task<MealTypeDto> Create(CreateMealTypeDto request, CancellationToken ctx = default);
    
    Task<MealTypeDto?> Update(Guid id, MealTypeDto updateDto, CancellationToken ctx = default);
    
    Task<bool> Delete(Guid id, CancellationToken ctx = default);
}