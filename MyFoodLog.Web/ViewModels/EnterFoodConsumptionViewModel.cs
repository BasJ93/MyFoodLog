using Material.Blazor;
using Microsoft.AspNetCore.Components;
using MyFoodLog.Web.API.Client.Interfaces;
using MyFoodLog.Web.State;

namespace MyFoodLog.Web.ViewModels;

public class EnterFoodConsumptionViewModel : ComponentBase
{
    [Inject]
    private IMBToastService? ToastService { get; set; }

    [Inject]
    private StateContainer? _stateContainer { get; set; }

    [Inject]
    private IMyFoodLogApi? FoodLogApi { get; set; }

    public MBDialog CreateFoodItemDialog { get; set; } = new();

    public MBDialog AddFoodConsumptionDialog { get; set; } = new();

    public string? SearchInput { get; set; }

    public bool HideResultSet { get; set; } = true;

    public List<FoodItemDto>? FoodItems { get; set; } = new();

    public async Task Search(CancellationToken ctx = default)
    {
        FoodItems?.Clear();

        if (SearchInput != null)
        {
            try
            {
                if (FoodLogApi != null)
                {
                    FoodItems = (await FoodLogApi.FoodItem_SearchAsync(SearchInput, "1", ctx)).ToList();
                }
            }
            catch (ApiException)
            {
                
            }

            if (FoodItems == null)
            {
                FoodItems = new();
            }

            // No items were found, so let's put the notification in.
            if (!FoodItems.Any())
            {
                FoodItems.Add(new() { Name = "No items found, click to add new.", Id = Guid.Empty });
            }

            HideResultSet = false;

            await InvokeAsync(StateHasChanged);
        }
    }

    public async Task FoodItemClicked(int index)
    {
        if (FoodItems?[index].Id == Guid.Empty)
        {
            await CreateFoodItemDialog.ShowAsync();
        }
        else
        {
            if (_stateContainer != null)
            {
                _stateContainer.SelectedFoodItem = FoodItems?[index];
            }

            await AddFoodConsumptionDialog.ShowAsync();
        }
    }
}