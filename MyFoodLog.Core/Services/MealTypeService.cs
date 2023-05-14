using AutoMapper;
using Microsoft.Extensions.Logging;
using MyFoodLog.Core.Services.Interfaces;
using MyFoodLog.Database.Models;
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

    public async Task<IEnumerable<MealTypeDto>> GetAll(CancellationToken ctx = default)
    {
        return _mapper.Map<IEnumerable<MealTypeDto>>(await _mealTypeRepository.All(ctx));
    }

    public async Task Create(CreateMealTypeDto request, CancellationToken ctx = default)
    {
        if (await _mealTypeRepository.ByName(request.Name, ctx) == null)
        {
            MealType mealType = new()
            {
                Name = request.Name
            };

            await _mealTypeRepository.InsertAndSave(mealType, ctx);
        }
    }
}