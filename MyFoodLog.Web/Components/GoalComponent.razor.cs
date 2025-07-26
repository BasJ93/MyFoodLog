using Material.Blazor;
using Microsoft.AspNetCore.Components;
using MyFoodLog.Web.API.Client.Interfaces;
using MyFoodLog.Web.State;

namespace MyFoodLog.Web.Components;

public partial class GoalComponent : ComponentBase
{
    [Parameter]
    public Func<IMyFoodLogApi, IMBToastService, CreateGoalDto, CancellationToken, Task<bool>>? FormHandler { get; set; }

    [Inject]
    private IMyFoodLogApi? FoodLogApi { get; set; }

    [Inject]
    private IMBToastService? ToastService { get; set; }

    [Inject]
    private StateContainer? StateContainer { get; set; }

    private string ButtonText { get; set; } = "Add";

    private CreateGoalDto CreateDto { get; } = new();

    private decimal Fat { get; set; }

    private decimal Carbohydrates { get; set; }

    private decimal Protein { get; set; }

    private async Task HandleForm(CancellationToken ctx = default)
    {
        if (FormHandler != null && FoodLogApi != null && ToastService != null)
        {
            CreateDto.Carbohydrates = Carbohydrates;
            CreateDto.Fat = Fat;
            CreateDto.Protein = Protein;
            
            await FormHandler(FoodLogApi, ToastService, CreateDto, ctx);
        }
    }
    
    protected override async Task OnInitializedAsync()
    {
        if (FoodLogApi != null)
        {
            try
            {
                decimal energyGoal = await FoodLogApi.Goal_GetEnergyAsync("1");

                CreateDto.Energy = energyGoal;

                MacrosGoalDto macrosGoalDto = await FoodLogApi.Goal_GetMacrosAsync("1");

                Fat = macrosGoalDto.Fat;
                Carbohydrates = macrosGoalDto.Carbohydrates;
                Protein = macrosGoalDto.Protein;

                if (CreateDto.Energy > 0)
                {
                    ButtonText = "Update";
                }

                StateHasChanged();
            }
            catch (ApiException)
            {
            }
        }

        await base.OnInitializedAsync();
    }
}