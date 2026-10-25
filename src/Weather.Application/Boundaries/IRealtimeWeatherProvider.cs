using Weather.Application.Models;

namespace Weather.Application.Boundaries;

public interface IRealtimeWeatherProvider
{
    Task<RealtimeWeather?> GetForCityAsync(string city, CancellationToken cancellationToken);
}