using AutoMapper;
using Microsoft.Extensions.Logging;
using MyFoodLog.Core.Services.Interfaces;
using MyFoodLog.Database.Repositories.Interfaces;
using MyFoodLog.Models.MealTypes;

namespace MyFoodLog.Core.Services;

public class MealTypeService : IMealTypeService
{
    private readonly ILogger<MealTypeService> _logger;
    private readonly IMealTypeRepository _mealTypeRepository;
    private readonly IMapper _mapper;

    public MealTypeService(ILogger<MealTypeService> logger, IMealTypeRepository mealTypeRepository, IMapper mapper)
    {
        _logger = logger;
        _mealTypeRepository = mealTypeRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MealTypeDto>> GetAll(CancellationToken ctx)
    {
        return _mapper.Map<IEnumerable<MealTypeDto>>(await _mealTypeRepository.All(ctx));
    }
}