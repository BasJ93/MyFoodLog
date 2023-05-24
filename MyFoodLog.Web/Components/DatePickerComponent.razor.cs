using Microsoft.AspNetCore.Components;

namespace MyFoodLog.Web.Components;

public partial class DatePickerComponent : ComponentBase
{
    [Parameter]
    public EventCallback<DateTime> DateChanged { get; set; }
    
    private DateTime _day = DateTime.Today;

    private DateTime Day
    {
        get => _day;
        set
        {
            _day = value;
            DateChanged.InvokeAsync(value);
        }
    }
    
    private void BackOneDay()
    {
        Day -= TimeSpan.FromDays(1);
    }

    private void ForwardOneDay()
    {
        Day += TimeSpan.FromDays(1);
    }
}