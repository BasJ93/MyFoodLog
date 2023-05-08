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
    
    public void FoodItemClicked(int index)
    {
        //var result = await CreateFoodItemDialog.ShowAsync();
        
        ToastService?.ShowToast(heading: "General Dialog", message: $"Value: ({index})", level: MBToastLevel.Success, showIcon: false);
    }
    
    public async Task FoodItemClicked(Guid id)
    {
        if (_stateContainer != null)
        {
            _stateContainer.SelectedFoodItem = FoodItems?.FirstOrDefault(f => f.Id == id);
        }
        
        var result = await AddFoodConsumptionDialog.ShowAsync();

        ToastService?.ShowToast(heading: "General Dialog", message: $"Value: ({id})", level: MBToastLevel.Success, showIcon: false);
    }
}