using AutoMapper;
using MyFoodLog.Models.FoodConsumption;
using MyFoodLog.Models.FoodItem;
using MyFoodLog.Core.Services.Interfaces;
using MyFoodLog.Database.Models;
using MyFoodLog.Database.Repositories.Interfaces;

namespace MyFoodLog.Core.Services;

/// <inheritdoc />
public class FoodItemService : IFoodItemService
{
    private readonly IFoodItemRepository _foodItems;

    private readonly IMapper _mapper;

    public FoodItemService(IFoodItemRepository foodItems, IMapper autoMapper)
    {
        _foodItems = foodItems;
        _mapper = autoMapper;
    }

    /// <inheritdoc />
    public async Task Create(CreateFoodItemDto dto, CancellationToken ctx)
    {
        /*bool canConvert = long.TryParse(dto.EAN13, out long ean13);
        
        FoodItem newFoodItem = new FoodItem()
        {
            Name = dto.Name,
            EAN13 = canConvert ? ean13 : null,
            Energy = dto.Energy,
            Carbohydrates = dto.Carbohydrates,
            Fat = dto.Fat,
            Protein = dto.Protein,
            QuantityUnit = dto.QuantityUnit
        };*/
        
        FoodItem newFoodItem = _mapper.Map<FoodItem>(dto);
        
        await _foodItems.InsertAndSave(newFoodItem, ctx);
    }

    /// <inheritdoc />
    public async Task<ICollection<FoodItemDto>> Search(SearchFoodDto searchDto, CancellationToken ctx)
    {
        List<FoodItem> matches = new();
        
        // Check if the search input only consists of numbers
        if (IsDigitsOnly(searchDto.SearchString))
        {
            FoodItem? item = await _foodItems.ByEAN13(Convert.ToInt64(searchDto.SearchString), ctx);
            if (item != null)
            {
                matches.Add(item);
            }
        }
        
        // If not, try to find the food by name
        if (!matches.Any())
        {
            // First from the internal db
            matches.AddRange(await _foodItems.SearchByName(searchDto.SearchString, ctx));
        }
        
        // Then from grocy
        if (!matches.Any())
        {
            
        }

        return _mapper.Map<List<FoodItemDto>>(matches);
    }
    
    private bool IsDigitsOnly(string str)
    {
        foreach (char c in str)
        {
            if (c < '0' || c > '9')
                return false;
        }

        return true;
    }
}