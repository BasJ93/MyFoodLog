using System.Net.Http.Json;
using Material.Blazor;
using Microsoft.AspNetCore.Components;
using MyFoodLog.Models.FoodItem;

namespace MyFoodLog.Web.ViewModels;

public class AddFoodItemViewModel : ComponentBase
{
    [Inject]
    private IConfiguration Configuration { get; set; }

    [Inject]
    private IMBToastService ToastService { get; set; }
    
    private HttpClient _httpClient = new();
    
    public CreateFoodItemDto CreateDto { get; set; } = new();

    public async Task SendCreateFoodItem(CancellationToken ctx = default)
    {
        string baseUrl = Configuration["baseUrl"] ?? string.Empty;
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{baseUrl}/api/v1/fooditem/create", CreateDto, ctx);

        if (response.IsSuccessStatusCode)
        {
            ToastService.ShowToast(MBToastLevel.Success, $"Successfully added {CreateDto.Name}.", timeout: 1500);
            StateHasChanged();
        }
    }
}