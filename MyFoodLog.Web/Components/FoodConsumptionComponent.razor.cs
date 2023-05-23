using Material.Blazor;
using Microsoft.AspNetCore.Components;
using MyFoodLog.Web.API.Client.Interfaces;
using MyFoodLog.Web.State;

namespace MyFoodLog.Web.Components;

public partial class FoodConsumptionComponent : ComponentBase
{
    [Parameter]
    public Func<IMyFoodLogApi, IMBToastService, AddConsumptionRequestDto, CancellationToken, Task<bool>>? FormHandler
    {
        get;
        set;
    }

    [Inject]
    private StateContainer? StateContainer { get; set; }

    [Inject]
    private IMBToastService? ToastService { get; set; }

    [Inject]
    private IMyFoodLogApi? FoodLogApi { get; set; }

    [Inject]
    private NavigationManager? NavigationService { get; set; }

    private string ButtonText { get; set; } = "Add";

    private bool NameWasProvided { get; set; }

    private bool MealWasProvided { get; set; }

    private AddConsumptionRequestDto AddConsumptionRequestDto { get; set; } = new();

    private List<MBSelectElement<Guid?>> Meals { get; set; } = new();


    protected override async Task OnInitializedAsync()
    {
        try
        {
            if (FoodLogApi != null)
            {
                ICollection<MealTypeDto> mealTypes =
                    await FoodLogApi.MealType_GetMealTypesAsync("1", CancellationToken.None) ?? new List<MealTypeDto>();


                Meals.Clear();

                foreach (MealTypeDto mealType in mealTypes)
                {
                    Meals.Add(new MBSelectElement<Guid?> { SelectedValue = mealType.Id, Label = mealType.Name });
                }
            }
        }
        catch (ApiException)
        {
        }

        await base.OnInitializedAsync();
    }

    protected override async Task OnParametersSetAsync()
    {
        if (StateContainer?.SelectedFoodConsumption != null)
        {
            AddConsumptionRequestDto.Name = StateContainer.SelectedFoodConsumption.Name;
            AddConsumptionRequestDto.Amount = StateContainer.SelectedFoodConsumption.Amount;
            NameWasProvided = true;
            MealWasProvided = true;
            ButtonText = "Update";
        }
        else
        {
            if (StateContainer?.SelectedFoodItem != null &&
                !string.IsNullOrEmpty(StateContainer.SelectedFoodItem.Name))
            {
                Console.WriteLine("SelectedFoodItem was not empty, and has a name");
                AddConsumptionRequestDto.Name = StateContainer.SelectedFoodItem.Name;
                NameWasProvided = true;

                if (!string.IsNullOrEmpty(StateContainer?.MealName))
                {
                    // TODO: This does not seem to make the select box then select this item.
                    AddConsumptionRequestDto.MealTypeId =
                        Meals.FirstOrDefault(m => m.Label == StateContainer.MealName)?.SelectedValue;

                    MealWasProvided = true;
                }
            }
        }

        await base.OnParametersSetAsync();
    }

    private async Task SubmitConsumption(CancellationToken ctx = default)
    {
        if (FormHandler != null && FoodLogApi != null && ToastService != null)
        {
            await FormHandler(FoodLogApi, ToastService, AddConsumptionRequestDto, ctx);
        }

        if (StateContainer != null)
        {
            StateContainer.MealName = string.Empty;
            StateContainer.SelectedFoodConsumption = null;
        }

        NavigationService?.NavigateTo(StateContainer?.PreviousPage ?? string.Empty);
    }
}