using Material.Blazor;
using Microsoft.AspNetCore.Components;
using MyFoodLog.Web.API.Client.Interfaces;
using MyFoodLog.Web.State;

namespace MyFoodLog.Web.Components;

public partial class AddFoodConsumptionComponent : ComponentBase
{
    [Inject]
    private StateContainer? StateContainer { get; set; }

    [Inject]
    private IMBToastService? ToastService { get; set; }
    
    [Inject]
    private IMyFoodLogApi? FoodLogApi { get; set; }

    private bool NameWasProvided { get; set; }

    private AddConsumptionRequestDto AddConsumptionRequestDto { get; set; } = new();

    private List<MBSelectElement<Guid?>> Meals { get; set; } = new ();

    protected override async Task OnInitializedAsync()
    {
        try
        {
            if (FoodLogApi != null)
            {
                ICollection<MealTypeDto> mealTypes = await FoodLogApi.MealType_GetMealTypesAsync("1", CancellationToken.None) ?? new List<MealTypeDto>();

                Meals.Clear();

                foreach (MealTypeDto mealType in mealTypes)
                {
                    Meals.Add(new MBSelectElement<Guid?>() { SelectedValue = mealType.Id, Label = mealType.Name });
                }
            }
        }
        catch (ApiException)
        {
            
        }

        await base.OnInitializedAsync();
    }
    
    protected override void OnInitialized()
    {
        base.OnInitialized();
        try
        {
            if (StateContainer != null)
            {
                Console.WriteLine("stateContainer was not empty");
                if (StateContainer.SelectedFoodItem != null && !string.IsNullOrEmpty(StateContainer.SelectedFoodItem.Name))
                {
                    Console.WriteLine("SelectedFoodItem was not empty, and has a name");
                    AddConsumptionRequestDto.Name = StateContainer.SelectedFoodItem.Name;
                    NameWasProvided = true;
                }
            }
        }
        catch (Exception)
        {
            Console.WriteLine("This somehow works but also throws an exception.");
        }
    }

    private async Task SubmitConsumption(CancellationToken ctx = default)
    {
        try
        {
            if (FoodLogApi != null)
            {
                await FoodLogApi.FoodConsumption_CreateAsync("1", AddConsumptionRequestDto, ctx);
                ToastService?.ShowToast(MBToastLevel.Success, $"Successfully added {AddConsumptionRequestDto.Amount} {StateContainer?.SelectedFoodItem?.QuantityUnit ?? string.Empty} of {AddConsumptionRequestDto.Name} to {Meals.First(m => m.SelectedValue == AddConsumptionRequestDto.MealTypeId).Label}.", timeout: 1500);
                StateHasChanged();
            }
        }
        catch (ApiException)
        {
            
        }
    }
}