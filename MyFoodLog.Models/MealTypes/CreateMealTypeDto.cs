using System.ComponentModel.DataAnnotations;

namespace MyFoodLog.Models.MealTypes;

public class CreateMealTypeDto
{
    [Required]
    public string Name { get; set; }
}