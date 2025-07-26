using MyFoodLog.Core.Mappers;
using MyFoodLog.Core.Services.Interfaces;
using MyFoodLog.Database.Models;
using MyFoodLog.Database.Repositories.Interfaces;
using MyFoodLog.Models.FoodConsumption;
using MyFoodLog.Models.FoodItem;

namespace MyFoodLog.Core.Services;

/// <inheritdoc />
public class FoodItemService : IFoodItemService
{
    private readonly IFoodItemRepository _foodItems;

    public FoodItemService(IFoodItemRepository foodItems)
    {
        _foodItems = foodItems;
    }

    /// <inheritdoc />
    public async Task<ICollection<FoodItemDto>> All(CancellationToken ctx = default)
    {
        IEnumerable<FoodItem> items = await _foodItems.All(ctx);

        return items.Select(FoodItemMapper.ToDto).ToList();
    }

    /// <inheritdoc />
    public async Task<FoodItemDto?> ById(Guid id, CancellationToken ctx = default)
    {
        FoodItem? item = await _foodItems.ById(id, ctx);

        return item.ToDto();
    }

    /// <inheritdoc />
    public async Task<FoodItemDto> Create(CreateFoodItemDto dto, CancellationToken ctx = default)
    {
        /*bool canConvert = long.TryParse(dto.EAN13, out long ean13);*/
        
        FoodItem newFoodItem = dto.ToModel();
        
        await _foodItems.InsertAndSave(newFoodItem, ctx);

        return newFoodItem.ToDto();
    }

    /// <inheritdoc />
    public async Task<bool> Delete(Guid id, CancellationToken ctx = default)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task<ICollection<FoodItemDto>> Search(SearchFoodDto searchDto, CancellationToken ctx = default)
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

        return matches.Select(FoodItemMapper.ToDto).ToList();
    }

    /// <inheritdoc />
    public async Task<FoodItemDto?> Update(Guid id, CreateFoodItemDto updateDto, CancellationToken ctx = default)
    {
        FoodItem? item = await _foodItems.ById(id, ctx);

        if (item != null)
        {
            item.Name = updateDto.Name;
            item.Energy = updateDto.Energy;
            item.QuantityUnit = updateDto.QuantityUnit;
            item.Fat = updateDto.Fat;
            item.Carbohydrates = updateDto.Carbohydrates;
            item.Protein = updateDto.Protein;
            
            int result = await _foodItems.UpdateAndSave(item, ctx);

            if (result == 1)
            {
                return item.ToDto();
            }
        }

        return null;
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