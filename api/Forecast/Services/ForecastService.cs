using System.Globalization;
using Constants;
using Forecast.Models;

namespace Forecast.Services;

public class ForecastService : IForecastService
{
    private HttpClient _httpClient;
    private ILogger _logger;

    public ForecastService(IHttpClientFactory httpClientFactory, ILogger<ForecastService> logger)
    {
        _httpClient = httpClientFactory.CreateClient(Api.WEATHER_HTTP_CLIENT);
        _logger = logger;
    }
    public async Task<List<Period>> GetForecastAsync(Coordinates coordinates)
    {
        try
        {

            var response = await _httpClient.GetFromJsonAsync<ForecastPointsResponse>($"points/{coordinates}");
            if (response is null)
            {
                return new List<Period>();
            }
            var forecastResponse = await _httpClient.GetFromJsonAsync<ForecastResponse>(response.Properties.Forecast);
            if (forecastResponse is null)
            {
                return new List<Period>();
            }
            return forecastResponse.Properties.Periods;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return new List<Period>();
        }

    }
}
