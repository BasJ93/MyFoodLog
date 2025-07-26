namespace MyFoodLog.Models.Goals;

public class CreateGoalDto
{
    public decimal Energy { get; set; }
    
    public decimal? Fat { get; set; }

    public decimal? Protein { get; set; }

    public decimal? Carbohydrates { get; set; }
}