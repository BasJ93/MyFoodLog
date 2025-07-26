using MyFoodLog.ClientApis.DependencyInjection;
using MyFoodLog.Core.DependencyInjection;
using MyFoodLog.Database.DependencyInjection;

string MyAllowedOrigins = "_MyAllowedOrigins";

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowedOrigins,
        policy =>
        {
            policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
            //policy.WithOrigins("https://localhost:7168", "http://localhost:5131");
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.AllowCredentials();
        });
});

builder.Services.AddProblemDetails();

builder.Services.AddApiVersioning();

builder.Services.AddControllers();
builder.Services.AddOpenFoodFacts();

builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddCoreServices();

builder.Services.AddOpenApiDocument();

WebApplication app = builder.Build();

app.UseExceptionHandler();
app.UseStatusCodePages();

app.UseCors(MyAllowedOrigins);

app.UseOpenApi();
app.UseSwaggerUi();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();