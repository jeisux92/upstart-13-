using System.Text;
using System.Text.Encodings.Web;
using Constants;
using Forecast.Models;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Forecast.Services;
public class GeocodingService : IGeocodingService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger _logger;

    public GeocodingService(IHttpClientFactory httpClientFactory, ILogger<GeocodingService> logger)
    {
        _httpClient = httpClientFactory.CreateClient(Api.GEOCODING_HTTP_CLIENT);
        _logger = logger;
    }


    public async Task<Coordinates?> GetCoordinatesAsync(string address)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<GeocodingResponse>($"geocoder/locations/onelineaddress?address={address}&benchmark=2020&format=json");

            if (response is null)
            {
                return null;
            }

            if (response.Result.AddressMatches is null || response.Result.AddressMatches.Count == 0)
            {
                return null;
            }

            return response.Result.AddressMatches[0].Coordinates;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }

    }
}

