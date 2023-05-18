using Material.Blazor;
using Microsoft.AspNetCore.Components;
using MyFoodLog.Web.API.Client.Interfaces;
using MyFoodLog.Web.State;

namespace MyFoodLog.Web.ViewModels;

public class EnterFoodConsumptionViewModel : ComponentBase
{
    [Inject]
    private StateContainer? _stateContainer { get; set; }

    [Inject]
    private IMyFoodLogApi? FoodLogApi { get; set; }
    
    protected MBDialog CreateFoodItemDialog { get; set; } = new();

    protected MBDialog AddFoodConsumptionDialog { get; set; } = new();

    protected string? SearchInput { get; set; }

    protected bool HideResultSet { get; set; } = true;

    protected List<FoodItemDto>? FoodItems { get; set; } = new();

    protected async Task Search(CancellationToken ctx = default)
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

    protected async Task<bool> CreateFoodItem(IMyFoodLogApi foodLogApi, IMBToastService toastService, CreateFoodItemDto createDto, CancellationToken ctx)
    {
        try
        {
            await foodLogApi.FoodItem_CreateFoodItemAsync("1", createDto, ctx);

            toastService.ShowToast(MBToastLevel.Success, $"Successfully added {createDto.Name}.", timeout: 1500);

            await CreateFoodItemDialog.HideAsync();
            StateHasChanged();

            return true;
        }
        catch (ApiException)
        {
        }

        return false;
    }

    protected async Task FoodItemClicked(int index)
    {
        if (FoodItems?[index].Id == Guid.Empty)
        {
            if (_stateContainer != null)
            {
                _stateContainer.SelectedFoodItem = new FoodItemDto { Name = SearchInput };
            }

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