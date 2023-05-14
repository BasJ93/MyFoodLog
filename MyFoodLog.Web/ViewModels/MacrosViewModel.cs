using Microsoft.AspNetCore.Components;
using MyFoodLog.Models;
using MyFoodLog.Web.Support;
using Newtonsoft.Json;
using PSC.Blazor.Components.Chartjs;
using PSC.Blazor.Components.Chartjs.Enums;
using PSC.Blazor.Components.Chartjs.Models.Pie;

namespace MyFoodLog.Web.ViewModels;

public class MacrosViewModel : ComponentBase
{
    [Inject]
    private IConfiguration? Configuration { get; set; }

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

        string baseUrl = Configuration?["baseUrl"] ?? string.Empty;

        HttpResponseMessage response =
            await _httpClient.GetAsync($"{baseUrl}/api/v1/day/macros", CancellationToken.None);

        if (response.IsSuccessStatusCode)
        {
            string listAsString = await response.Content.ReadAsStringAsync(CancellationToken.None);

            macros = JsonConvert.DeserializeObject<MacrosDto>(listAsString) ?? new();
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