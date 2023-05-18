using Material.Blazor;
using Microsoft.AspNetCore.Components;
using MyFoodLog.Web.API.Client.Interfaces;

namespace MyFoodLog.Web.Components;

public partial class MealOverviewComponent : ComponentBase
{
    [Parameter]
    public MealDto? Meal { get; set; }
    
    [Inject]
    private IMyFoodLogApi? FoodLogApi { get; set; }

    [Inject]
    private IMBToastService? ToastService { get; set; }
    
    private async Task DeleteConsumption(Guid id, CancellationToken ctx = default)
    {
        try
        {
            if (FoodLogApi != null)
            {
                await FoodLogApi.FoodConsumption_DeleteAsync(id, "1", ctx);

                // await GetDayOverview(ctx);

                ToastService?.ShowToast(MBToastLevel.Success, $"Removed entry.", timeout: 1500);
                
                await InvokeAsync(StateHasChanged);
            }
        }
        catch (ApiException)
        {
        }
    }

    protected override void OnInitialized()
    {
        if (Meal != null)
        {
            Meal.Energy = Meal.ConsumedFood.Sum(c => c.Energy);
        }
        
        base.OnInitialized();
    }
}