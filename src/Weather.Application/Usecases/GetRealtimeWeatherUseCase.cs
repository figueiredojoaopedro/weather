using Weather.Application.Boundaries;
using Weather.Application.Models;

namespace Weather.Application.Usecases;

public sealed class GetRealtimeWeatherUseCase(IRealtimeWeatherProvider weatherProvider)
{
    public Task<RealtimeWeather?> ExecuteAsync(string city, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(city);
        return weatherProvider.GetForCityAsync(city.Trim(), cancellationToken);
    }
}