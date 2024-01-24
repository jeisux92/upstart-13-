using Forecast.Models;

namespace Forecast.Services;

public interface IGeocodingService
{
    Task<Coordinates?> GetCoordinatesAsync(string address);
}
