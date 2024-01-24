using Forecast.Models;

namespace Forecast.Services;
public interface IForecastService
{
    Task<List<Period>> GetForecastAsync(Coordinates coordinates);
}
