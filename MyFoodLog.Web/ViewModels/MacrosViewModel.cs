using Microsoft.AspNetCore.Components;
using MyFoodLog.Web.API.Client.Interfaces;
using MyFoodLog.Web.Shared;
using MyFoodLog.Web.Support;
using PSC.Blazor.Components.Chartjs;
using PSC.Blazor.Components.Chartjs.Enums;
using PSC.Blazor.Components.Chartjs.Models.Pie;

namespace MyFoodLog.Web.ViewModels;

public class MacrosViewModel : ComponentBase
{
    [CascadingParameter]
    public MainLayoutMaterial? Layout { get; set; }
    
    [Inject]
    private IMyFoodLogApi? FoodLogApi { get; set; }

    public PieChartConfig? PieChartConfig { get; set; }

    public Chart? MacrosPieChart { get; set; } = new();

    public MacrosViewModel()
    {
        PieChartConfig = new()
        {
            Options = new PieOptions
            {
                Responsive = true,
                MaintainAspectRatio = true
            }
        };

        PieChartConfig.Data.Labels = new List<string> { "Carbohydrates", "Fat", "Protein" };
    }

    protected override async Task OnInitializedAsync()
    {
        if (Layout != null)
        {
            Layout.Title = "Macros";
        }

        await UpdateChart(DateTime.Now, CancellationToken.None);

        await base.OnInitializedAsync();

        await InvokeAsync(StateHasChanged);
    }
    
    protected async Task DateChanged(DateTime obj)
    {
        await UpdateChart(obj, CancellationToken.None);
    }

    private async Task UpdateChart(DateTime date, CancellationToken ctx = default)
    {
        MacrosDto macros = new();

        try
        {
            if (FoodLogApi != null)
            {
                macros = await FoodLogApi.Day_MacrosForDayAsync(date, "1", CancellationToken.None);
            }
        }
        catch (ApiException)
        {
            
        }
        
        // Updating the data in the chart requires the creation of a new configuration.
        PieChartConfig = new()
        {
            Type = ChartType.Pie,
            Options = new PieOptions
            {
                Responsive = true,
                MaintainAspectRatio = true
            }
        };

        PieChartConfig.Data.Labels = new List<string> { "Carbohydrates", "Fat", "Protein" };

        PieChartConfig.Data.Datasets.Add(new PieDataset()
        {
            Data = new List<decimal> { macros.CarbohydratesPercentage, macros.FatPercentage, macros.ProteinPercentage },
            BackgroundColor = Colors.Palette1,
        });
    }
    
}