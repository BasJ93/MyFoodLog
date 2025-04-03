using Material.Blazor;
using Microsoft.AspNetCore.Components;
using MyFoodLog.Web.API.Client.Interfaces;
using MyFoodLog.Web.State;

namespace MyFoodLog.Web.Components;

public partial class MealTypeComponent : ComponentBase
{
    [Parameter]
    public Func<IMyFoodLogApi, IMBToastService, CreateMealTypeDto, CancellationToken, Task<bool>>? FormHandler { get; set; }
    
    [Inject]
    private IMyFoodLogApi? FoodLogApi { get; set; }
    
    [Inject]
    private IMBToastService? ToastService { get; set; }

    [Inject]
    private StateContainer? StateContainer { get; set; }

    private string ButtonText { get; set; } = "Add";
    
    private CreateMealTypeDto CreateDto { get; } = new();
    
    private async Task HandleForm(CancellationToken ctx = default)
    {
        if (FormHandler != null && FoodLogApi != null && ToastService != null)
        {
            await FormHandler(FoodLogApi, ToastService, CreateDto, ctx);
        }
    }

    protected override void OnInitialized()
    {
        if (StateContainer?.SelectedMealType != null)
        {
            CreateDto.Name = StateContainer.SelectedMealType.Name;
            ButtonText = "Update";
        }
        
        StateHasChanged();
        
        base.OnInitialized();
    }
}