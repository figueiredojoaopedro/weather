using Weather.Application.Boundaries;
using Weather.Application.Models;

namespace Weather.Infrastructure.OpenMeteo;

public sealed class OpenMeteoWeatherProvider(
    IOpenMeteoGeocodingApi geocodingApi,
    IOpenMeteoForecastApi forecastApi) : IRealtimeWeatherProvider
{
    private const string CurrentFields =
        "temperature_2m,relative_humidity_2m,apparent_temperature,is_day,weather_code,wind_speed_10m,wind_direction_10m";

    public async Task<RealtimeWeather?> GetForCityAsync(string city, CancellationToken cancellationToken)
    {
        var geocoding = await geocodingApi.SearchAsync(
            city,
            count: 1,
            language: "en",
            format: "json",
            cancellationToken);

        var location = geocoding.Results?.FirstOrDefault();
        if (location is null)
        {
            return null;
        }

        var forecast = await forecastApi.GetForecastAsync(
            location.Latitude,
            location.Longitude,
            CurrentFields,
            timezone: "UTC",
            wind_speed_unit: "kmh",
            cancellationToken);

        var current = forecast.Current;
        return new RealtimeWeather(
            location.Country is null ? location.Name : $"{location.Name}, {location.Country}",
            new DateTimeOffset(DateTime.SpecifyKind(current.Time, DateTimeKind.Utc)),
            current.Temperature_2m,
            current.Relative_humidity_2m,
            current.Apparent_temperature,
            current.Is_day == 1,
            current.Weather_code,
            current.Wind_speed_10m,
            current.Wind_direction_10m);
    }
}