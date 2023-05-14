using Material.Blazor;
using Microsoft.AspNetCore.Components;
using MyFoodLog.Models.FoodItem;
using MyFoodLog.Web.State;
using Newtonsoft.Json;

namespace MyFoodLog.Web.ViewModels;

public class EnterFoodConsumptionViewModel : ComponentBase
{
    [Inject]
    private IConfiguration? Configuration { get; set; }

    [Inject]
    private IMBToastService? ToastService { get; set; }
    
    [Inject]
    private StateContainer? _stateContainer { get; set; }
    
    private HttpClient _httpClient = new();

    public MBDialog CreateFoodItemDialog { get; set; } = new();
    
    public MBDialog AddFoodConsumptionDialog { get; set; } = new();
    
    public string? SearchInput { get; set; }

    public bool HideResultSet { get; set; } = true;
    
    public List<FoodItemDto>? FoodItems { get; set; } = new();

    public async Task Search(CancellationToken ctx = default)
    {
        string baseUrl = Configuration?["baseUrl"] ?? string.Empty;

        FoodItems?.Clear();

        if (SearchInput != null)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{baseUrl}/api/v1/fooditem/search?searchString={SearchInput}", ctx);

            if (response.IsSuccessStatusCode)
            {
                string listAsString = await response.Content.ReadAsStringAsync(ctx);

                FoodItems = JsonConvert.DeserializeObject<List<FoodItemDto>>(listAsString);
            }

            if (FoodItems == null)
            {
                FoodItems = new();
            }
            
            // No items were found, so let's put the notification in.
            if (!FoodItems.Any())
            {
                FoodItems.Add(new(){Name = "No items found, click to add new.", Id = Guid.Empty});
            }
                
            HideResultSet = false;

            await InvokeAsync(StateHasChanged);
        }
    }
    
    public async Task FoodItemClicked(int index)
    {
        if (FoodItems?[index].Id == Guid.Empty)
        {
            await CreateFoodItemDialog.ShowAsync();
        }
        else
        {
            if (_stateContainer != null)
            {
                _stateContainer.SelectedFoodItem = FoodItems?[index];
            }

            await AddFoodConsumptionDialog.ShowAsync();
        }
    }
}