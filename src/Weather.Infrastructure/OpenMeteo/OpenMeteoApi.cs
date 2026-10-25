using Refit;

namespace Weather.Infrastructure.OpenMeteo;

public interface IOpenMeteoGeocodingApi
{
    [Get("/v1/search")]
    Task<GeocodingResponse> SearchAsync(
        [Query] string name,
        [Query] int count,
        [Query] string language,
        [Query] string format,
        CancellationToken cancellationToken);
}

public interface IOpenMeteoForecastApi
{
    [Get("/v1/forecast")]
    Task<ForecastResponse> GetForecastAsync(
        [Query] double latitude,
        [Query] double longitude,
        [Query] string current,
        [Query] string timezone,
        [Query] string wind_speed_unit,
        CancellationToken cancellationToken);
}

public sealed record GeocodingResponse(IReadOnlyList<GeocodingResult>? Results);

public sealed record GeocodingResult(
    string Name,
    double Latitude,
    double Longitude,
    string? Country);

public sealed record ForecastResponse(ForecastCurrent Current);

public sealed record ForecastCurrent(
    DateTime Time,
    double Temperature_2m,
    int Relative_humidity_2m,
    double Apparent_temperature,
    int Is_day,
    int Weather_code,
    double Wind_speed_10m,
    int Wind_direction_10m);