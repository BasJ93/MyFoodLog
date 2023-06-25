using Blazored.LocalStorage;
using Material.Blazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyFoodLog.Web;
using MyFoodLog.Web.API.Client;
using MyFoodLog.Web.API.Client.Interfaces;
using MyFoodLog.Web.State;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// The custom HttpClient sets its base url based on the config file.
builder.Services.AddScoped<ICustomHttpClient, CustomHttpClient>();

builder.Services.AddScoped<IMyFoodLogApi, MyFoodLogApi>();

builder.Services.AddSingleton<StateContainer>();

builder.Services.AddMBServices();

await builder.Build().RunAsync();