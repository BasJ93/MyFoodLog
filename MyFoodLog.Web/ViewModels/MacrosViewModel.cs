using Microsoft.AspNetCore.Components;
using MyFoodLog.Web.Support;
using PSC.Blazor.Components.Chartjs;
using PSC.Blazor.Components.Chartjs.Models.Pie;

namespace MyFoodLog.Web.ViewModels;

public class MacrosViewModel : ComponentBase
{
    public PieChartConfig? PieChartConfig { get; }

    public Chart? MacrosPieChart { get; set; }

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
    }
    
    protected override async Task OnInitializedAsync()
    {
        if (PieChartConfig != null)
        {
            PieChartConfig.Data.Labels = new List<string> { "Carbohydrates", "Fat", "Protein" };
            PieChartConfig.Data.Datasets.Add(new PieDataset()
            {
                Data = new List<decimal> { 50, 30, 20 },
                BackgroundColor = Colors.Palette1,
            });
        }

        await InvokeAsync(StateHasChanged);
    }
}