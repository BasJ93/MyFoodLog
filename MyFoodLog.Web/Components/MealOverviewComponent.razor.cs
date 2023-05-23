using Material.Blazor;
using Microsoft.AspNetCore.Components;
using MyFoodLog.Web.API.Client.Interfaces;
using MyFoodLog.Web.State;

namespace MyFoodLog.Web.Components;

public partial class MealOverviewComponent : ComponentBase
{
    [Parameter]
    public MealDto? Meal { get; set; }
    
    [Parameter]
    public EventCallback CollectionModified { get; set; }
    
    [Inject]
    private IMyFoodLogApi? FoodLogApi { get; set; }

    [Inject]
    private IMBToastService? ToastService { get; set; }
    
    [Inject]
    private StateContainer? _stateContainer { get; set; }
    
    [Inject]
    private NavigationManager? NavigationService { get; set; }
    
    private async Task DeleteConsumption(Guid id, CancellationToken ctx = default)
    {
        try
        {
            if (FoodLogApi != null)
            {
                await FoodLogApi.FoodConsumption_DeleteAsync(id, "1", ctx);;

                ToastService?.ShowToast(MBToastLevel.Success, $"Removed entry.", timeout: 1500);

                await CollectionModified.InvokeAsync();
            }
        }
        catch (ApiException)
        {
        }
    }
    
    private async Task EditConsumption(Guid id, CancellationToken ctx = default)
    {
        if (_stateContainer != null)
        {
            _stateContainer.PreviousPage = NavigationService?.Uri ?? string.Empty;
            _stateContainer.SelectedFoodConsumption = Meal?.ConsumedFood?.FirstOrDefault(c => c.Id == id);
        }
        
        NavigationService?.NavigateTo("editFoodConsumption");
    }

    private async Task AddFoodItem(CancellationToken ctx = default)
    {
        if (_stateContainer != null)
        {
            _stateContainer.PreviousPage = NavigationService?.Uri ?? string.Empty;
            _stateContainer.MealName = Meal?.Name ?? string.Empty;
        }

        NavigationService?.NavigateTo("addConsumption");
    }
    
    private void CalculateEnergy()
    {
        if (Meal != null)
        {
            Meal.Energy = Meal.ConsumedFood.Sum(c => c.Energy);
        }
    }

    protected override void OnParametersSet()
    {
        CalculateEnergy();
        
        base.OnParametersSet();
    }
}