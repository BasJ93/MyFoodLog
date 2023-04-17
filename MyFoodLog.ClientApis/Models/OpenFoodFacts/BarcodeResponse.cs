using Newtonsoft.Json;

namespace MyFoodLog.ClientApis.Models.OpenFoodFacts;

public class BarcodeResponse
{
    public string? Code { get; set; }

    public Product? Product { get; set; }

    public int Status { get; set; }

    [JsonProperty("status_verbose")]
    public string VerboseStatus { get; set; }
}

public class Product
{
    public Nutriments? Nutriments { get; set; }
    
    [JsonProperty("product_name")]
    public string? Name { get; set; }
}

public class Nutriments
{
    public decimal Carbohydrates { get; set; }

    [JsonProperty("carbohydrates_100g")]
    public decimal Carbohydrates100g { get; set; }

    [JsonProperty("carbohydrates_serving")]
    public decimal CarbohydratesServing { get; set; }

    [JsonProperty("carbohydrates_unit")]
    public string? CarbohydratesUnit { get; set; }

    [JsonProperty("carbohydrates_value")]
    public decimal CarbohydratesValue { get; set; }

    [JsonProperty("energy")]
    public decimal Energy { get; set; }

    [JsonProperty("energy-kcal")]
    public decimal EnergyKCal { get; set; }

    [JsonProperty("energy-kcal_100g")]
    public decimal EnergyKCal100g { get; set; }

    [JsonProperty("energy-kcal_serving")]
    public decimal EnergyKCalServing { get; set; }

    [JsonProperty("energy-kcal_unit")]
    public string? EnergyKCalUnit { get; set; }

    [JsonProperty("energy-kcal_value")]
    public decimal EnergyKCalValue { get; set; }

    [JsonProperty("energy_100g")]
    public decimal Energy100g { get; set; }

    [JsonProperty("energy_serving")]
    public decimal EnergyServing { get; set; }

    [JsonProperty("energy_unit")]
    public string? EnergyUnit { get; set; }

    [JsonProperty("energy_value")]
    public decimal EnergyValue { get; set; }

    [JsonProperty("fat")]
    public decimal Fat { get; set; }

    [JsonProperty("fat_100g")]
    public decimal Fat100g { get; set; }

    [JsonProperty("fat_serving")]
    public decimal FatServing { get; set; }

    [JsonProperty("fat_unit")]
    public string? FatUnit { get; set; }

    [JsonProperty("fat_value")]
    public decimal FatValue { get; set; }

    [JsonProperty("fiber")]
    public decimal Fiber { get; set; }

    [JsonProperty("fiber_100g")]
    public decimal Fiber100g { get; set; }

    [JsonProperty("fiber_serving")]
    public decimal FiberServing { get; set; }

    [JsonProperty("fiber_unit")]
    public string? FiberUnit { get; set; }

    [JsonProperty("fiber_value")]
    public decimal FiberValue { get; set; }

    [JsonProperty("fruits-vegetables-nuts-estimate-from-ingredients_100g")]
    public decimal FruitsVegetablesNutsEstimateFromIngredients_100g { get; set; }

    [JsonProperty("nova-group")]
    public decimal NovaGroup { get; set; }

    [JsonProperty("nova-group_100g")]
    public decimal NovaGroup_100g { get; set; }

    [JsonProperty("nova-group_serving")]
    public decimal NovaGroupServing { get; set; }

    [JsonProperty("nutrition-score-fr")]
    public decimal NutritionScoreFr { get; set; }

    [JsonProperty("nutrition-score-fr_100g")]
    public decimal NutritionScoreFr_100g { get; set; }

    [JsonProperty("proteins")]
    public decimal Proteins { get; set; }

    [JsonProperty("proteins_100g")]
    public decimal Proteins100g { get; set; }

    [JsonProperty("proteins_serving")]
    public decimal ProteinsServing { get; set; }

    [JsonProperty("proteins_unit")]
    public string? ProteinsUnit { get; set; }

    [JsonProperty("proteins_value")]
    public decimal ProteinsValue { get; set; }
}