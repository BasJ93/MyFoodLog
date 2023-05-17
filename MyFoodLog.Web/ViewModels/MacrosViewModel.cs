using Microsoft.AspNetCore.Components;
using MyFoodLog.Web.API.Client.Interfaces;
using MyFoodLog.Web.Support;
using PSC.Blazor.Components.Chartjs;
using PSC.Blazor.Components.Chartjs.Enums;
using PSC.Blazor.Components.Chartjs.Models.Pie;

namespace MyFoodLog.Web.ViewModels;

public class MacrosViewModel : ComponentBase
{
    [Inject]
    private IMyFoodLogApi? FoodLogApi { get; set; }

    private HttpClient _httpClient = new();

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
        MacrosDto macros = new();

        try
        {
            if (FoodLogApi != null)
            {
                macros = await FoodLogApi.Day_MacrosForDayAsync(null, CancellationToken.None);
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
            Data = new List<decimal> { macros.Carbohydrates, macros.Fat, macros.Protein },
            BackgroundColor = Colors.Palette1,
        });

        await base.OnInitializedAsync();

        await InvokeAsync(StateHasChanged);
    }
}