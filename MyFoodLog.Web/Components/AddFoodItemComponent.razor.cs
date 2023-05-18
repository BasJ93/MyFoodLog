using Material.Blazor;
using Microsoft.AspNetCore.Components;
using MyFoodLog.Web.API.Client.Interfaces;
using MyFoodLog.Web.State;

namespace MyFoodLog.Web.Components;

public partial class AddFoodItemComponent : ComponentBase
{
    [Parameter]
    public Func<IMyFoodLogApi, IMBToastService, CreateFoodItemDto, CancellationToken, Task<bool>>? FormHandler { get; set; }
    
    [Inject]
    private IMyFoodLogApi? FoodLogApi { get; set; }
    
    [Inject]
    private IMBToastService? ToastService { get; set; }

    [Inject]
    private StateContainer? StateContainer { get; set; }

    private string ButtonText { get; set; } = "Add";
    
    private CreateFoodItemDto CreateDto { get; } = new();

    private async Task HandleForm(CancellationToken ctx = default)
    {
        if (FormHandler != null && FoodLogApi != null && ToastService != null)
        {
            await FormHandler(FoodLogApi, ToastService, CreateDto, ctx);
        }
    }

    protected override void OnInitialized()
    {
        if (StateContainer?.SelectedFoodItem != null)
        {
            CreateDto.Name = StateContainer.SelectedFoodItem.Name;
            CreateDto.Energy = StateContainer.SelectedFoodItem.Energy;
            CreateDto.Fat = StateContainer.SelectedFoodItem.Fat;
            CreateDto.Carbohydrates = StateContainer.SelectedFoodItem.Carbohydrates;
            CreateDto.Protein = StateContainer.SelectedFoodItem.Protein;
            CreateDto.QuantityUnit = StateContainer.SelectedFoodItem.QuantityUnit;

            if (CreateDto.Energy > 0)
            {
                ButtonText = "Update";
            }
        }
        
        StateHasChanged();
        
        base.OnInitialized();
    }
}