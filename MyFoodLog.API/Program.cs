using Hellang.Middleware.ProblemDetails;
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

builder.Services.AddProblemDetails(options =>
{
    options.IncludeExceptionDetails = (ctx, ex) => builder.Environment.IsDevelopment();
});

builder.Services.AddControllers();
builder.Services.AddOpenFoodFacts();

builder.Services.AddDatabase();
builder.Services.AddCoreServices();

builder.Services.AddAutoMapper(typeof(Profiles));

builder.Services.AddOpenApiDocument();

var app = builder.Build();

app.UseCors(MyAllowedOrigins);

app.UseOpenApi();
app.UseSwaggerUi3();

app.UseProblemDetails();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();