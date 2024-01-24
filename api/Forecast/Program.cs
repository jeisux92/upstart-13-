using Constants;
using Forecast.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var geocodingUrl = builder.Configuration.GetValue<string>("GeocodingUrl") ?? "http://fakeurl.com";
var weatherUrl = builder.Configuration.GetValue<string>("WeatherUrl") ?? "http://fakeurl.com";

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PizzaStore API", Description = "Making the Pizzas you love", Version = "v1" });
});
builder.Services.AddScoped<IForecastService, ForecastService>();
builder.Services.AddScoped<IGeocodingService, GeocodingService>();

builder.Services.AddHttpClient(Api.GEOCODING_HTTP_CLIENT, c =>
{
    c.BaseAddress = new Uri(geocodingUrl);
});

builder.Services.AddHttpClient(Api.WEATHER_HTTP_CLIENT, c =>
{
    c.BaseAddress = new Uri(weatherUrl);
    c.DefaultRequestHeaders.Add("User-Agent", "forecast api");
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddLogging();
var app = builder.Build();
app.UseCors("AllowAll");
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Forecast API V1");
});
app.MapGet("/forecast/{address:required}", async (string address, IForecastService forecastService, IGeocodingService geocodingService) =>
{
    var coordinates = await geocodingService.GetCoordinatesAsync(address);
    if (coordinates is null)
    {
        return Results.NotFound();
    }

    var forecast = await forecastService.GetForecastAsync(coordinates);
    if (forecast.Any())
    {
        return Results.Ok(forecast);
    }
    return Results.NotFound();

});

app.Run();
