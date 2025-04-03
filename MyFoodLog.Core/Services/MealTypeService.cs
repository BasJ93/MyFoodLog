using AutoMapper;
using Microsoft.Extensions.Logging;
using MyFoodLog.Core.Services.Interfaces;
using MyFoodLog.Database.Models;
using MyFoodLog.Database.Repositories.Interfaces;
using MyFoodLog.Models.MealTypes;

namespace MyFoodLog.Core.Services;

/// <inheritdoc />
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

    /// <inheritdoc />
    public async Task<IEnumerable<MealTypeDto>> GetAll(CancellationToken ctx = default)
    {
        return _mapper.Map<IEnumerable<MealTypeDto>>(await _mealTypeRepository.All(ctx));
    }

    /// <inheritdoc />
    public async Task<MealTypeDto> Create(CreateMealTypeDto request, CancellationToken ctx = default)
    {
        MealType? existing = await _mealTypeRepository.ByName(request.Name, ctx);
        if (existing == null)
        {
            MealType mealType = new()
            {
                Name = request.Name
            };

            await _mealTypeRepository.InsertAndSave(mealType, ctx);

            return _mapper.Map<MealTypeDto>(mealType);
        }

        return _mapper.Map<MealTypeDto>(existing);
    }

    public async Task<MealTypeDto?> Update(Guid id, CreateMealTypeDto updateDto, CancellationToken ctx = default)
    {
        MealType? existing = await _mealTypeRepository.ById(id, ctx);
        if (existing == null)
        {
            return null;
        }
        
        //existing = _mapper.Map(updateDto, existing);
        
        existing.Name = updateDto.Name;
        
        await _mealTypeRepository.UpdateAndSave(existing, ctx);
        
        return _mapper.Map<MealTypeDto>(existing);
    }

    /// <inheritdoc />
    public async Task<bool> Delete(Guid id, CancellationToken ctx = default)
    {
        try
        {
            if (await _mealTypeRepository.ById(id, ctx) != null)
            {
                await _mealTypeRepository.DeleteAndSave(id, ctx);
                return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return false;
        }
    }
}