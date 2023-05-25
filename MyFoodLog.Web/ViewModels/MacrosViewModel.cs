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

    protected PieChartConfig? PieChartConfig { get; set; }

    protected Chart? MacrosPieChart { get; set; } = new();

    protected ICollection<MacroTableRow> MacroTableRows { get; set; } = new List<MacroTableRow>();

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
        
        await InvokeAsync(StateHasChanged);
    }

    private async Task UpdateChart(DateTime date, CancellationToken ctx = default)
    {
        MacrosDto macros = new();

        try
        {
            if (FoodLogApi != null)
            {
                macros = await FoodLogApi.Day_MacrosForDayAsync(date, "1", CancellationToken.None);
                
                MacroTableRows.Clear();
                
                MacroTableRows.Add(new("Carbohydrates", macros.Carbohydrates, macros.CarbohydratesPercentage, 50, 30));
                MacroTableRows.Add(new("Fat", macros.Fat, macros.FatPercentage, 30, 20));
                MacroTableRows.Add(new("Protein", macros.Protein, macros.ProteinPercentage, 20, 50));
                
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

    protected class MacroTableRow
    {
        public string Macro { get; set; }
        
        public decimal ConsumedValue { get; set; }
        
        public decimal ConsumedPercentage { get; set; }
        
        public decimal RecommendedPercentage { get; set; }
        
        public decimal WeightLossPercentage { get; set; }

        public MacroTableRow(string macro, decimal consumedValue, decimal consumedPercentage, decimal recommendedPercentage, decimal weightLossPercentage)
        {
            Macro = macro;
            ConsumedValue = consumedValue;
            ConsumedPercentage = consumedPercentage;
            RecommendedPercentage = recommendedPercentage;
            WeightLossPercentage = weightLossPercentage;
        }
    }
}