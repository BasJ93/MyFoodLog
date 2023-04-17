using MyFoodLog.ClientApis.DependencyInjection;
using MyFoodLog.Core.AutoMapper;
using MyFoodLog.Core.DependencyInjection;
using MyFoodLog.Database.DependencyInjection;

string MyAllowedOrigins = "_MyAllowedOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowedOrigins,
        policy =>
        {
            policy.WithOrigins("https://localhost:7168", "http://localhost:5131");
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.AllowCredentials();
        });
});

builder.Services.AddControllers();
builder.Services.AddOpenFoodFacts();

builder.Services.AddDatabase();
builder.Services.AddCoreServices();

builder.Services.AddAutoMapper(typeof(Profiles));

builder.Services.AddSwaggerDocument();

var app = builder.Build();

app.UseCors(MyAllowedOrigins);

app.MapControllers();

app.UseOpenApi();
app.UseSwaggerUi3();

app.MapGet("/", () => "Hello World!");

app.Run();