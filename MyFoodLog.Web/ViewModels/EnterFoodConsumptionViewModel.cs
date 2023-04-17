using Material.Blazor;
using Microsoft.AspNetCore.Components;
using MyFoodLog.Core.Models.FoodItem;
using Newtonsoft.Json;

namespace MyFoodLog.Web.ViewModels;

public class EnterFoodConsumptionViewModel : ComponentBase
{
    [Inject]
    private IConfiguration _configuration { get; set; }

    private HttpClient _httpClient = new();

    public MBDialog CreateFoodItemDialog { get; set; } = new();
    
    public string? SearchInput { get; set; }

    public bool HideResultSet { get; set; } = true;
    
    public List<FoodItemDto>? FoodItems { get; set; } = new();

    public async Task Search(CancellationToken ctx = default)
    {
        string baseUrl = _configuration["baseUrl"] ?? string.Empty;


        if (SearchInput != null)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{baseUrl}/api/v1/fooditem/search?searchString={SearchInput}", ctx);

            if (response.IsSuccessStatusCode)
            {
                string listAsString = await response.Content.ReadAsStringAsync(ctx);

                FoodItems = JsonConvert.DeserializeObject<List<FoodItemDto>>(listAsString);

                // TODO: Handle adding a placeholder item that indicates no items were found. This item should then trigger showing the "create new item" form.
                
                HideResultSet = false;

                await InvokeAsync(StateHasChanged);
            }
        }
    }
}