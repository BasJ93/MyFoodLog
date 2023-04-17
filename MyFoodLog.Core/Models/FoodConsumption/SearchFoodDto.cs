using System.ComponentModel.DataAnnotations;

namespace MyFoodLog.Core.Models.FoodConsumption;

public class SearchFoodDto
{
    [Required]
    public string SearchString { get; set; } = string.Empty;

    public SearchFoodDto()
    {
        
    }

    public SearchFoodDto(string searchString)
    {
        SearchString = searchString;
    }
}