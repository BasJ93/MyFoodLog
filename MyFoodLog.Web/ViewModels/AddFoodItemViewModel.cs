using Material.Blazor;
using Microsoft.AspNetCore.Components;
using MyFoodLog.Web.API.Client.Interfaces;

namespace MyFoodLog.Web.ViewModels;

public class AddFoodItemViewModel : ComponentBase
{
    [Inject]
    private IMyFoodLogApi? FoodLogApi { get; set; }
    
    [Inject]
    private IMBToastService? ToastService { get; set; }
    
    public CreateFoodItemDto CreateDto { get; set; } = new();

    public async Task SendCreateFoodItem(CancellationToken ctx = default)
    {

        try
        {
            if (FoodLogApi != null)
            {
                await FoodLogApi.FoodItem_CreateFoodItemAsync("1", CreateDto, ctx);
                
                ToastService?.ShowToast(MBToastLevel.Success, $"Successfully added {CreateDto.Name}.", timeout: 1500);
                StateHasChanged();
            }
        }
        catch (ApiException)
        {
            
        }
    }
}