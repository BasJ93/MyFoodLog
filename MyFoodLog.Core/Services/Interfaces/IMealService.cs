using MyFoodLog.Models;

namespace MyFoodLog.Core.Services.Interfaces;

public interface IMealService
{
    Task Create(CreateMealRequestDto requestDto, CancellationToken ctx = default);

    Task CalculateValues(CancellationToken ctx = default);
}