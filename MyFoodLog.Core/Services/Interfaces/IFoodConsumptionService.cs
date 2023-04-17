using MyFoodLog.Core.Models;
using MyFoodLog.Core.Models.FoodConsumption;
using MyFoodLog.Database.Models;

namespace MyFoodLog.Core.Services.Interfaces;

public interface IFoodConsumptionService
{
    Task AddConsumption(AddConsumptionRequestDto requestDto, CancellationToken ctx);
    
    Task UpdateConsumption(CancellationToken ctx);

    Task DeleteConsumption(CancellationToken ctx);
}