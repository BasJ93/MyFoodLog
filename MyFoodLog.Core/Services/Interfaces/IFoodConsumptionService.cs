using MyFoodLog.Models;

namespace MyFoodLog.Core.Services.Interfaces;

public interface IFoodConsumptionService
{
    Task AddConsumption(AddConsumptionRequestDto requestDto, CancellationToken ctx);
    
    Task UpdateConsumption(CancellationToken ctx);

    Task DeleteConsumption(CancellationToken ctx);
}