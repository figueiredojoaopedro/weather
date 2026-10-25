namespace Weather.Application.Models;

public sealed record RealtimeWeather(
    string Location,
    DateTimeOffset Time,
    double TemperatureCelsius,
    int RelativeHumidityPercent,
    double ApparentTemperatureCelsius,
    bool IsDay,
    int WeatherCode,
    double WindSpeedKilometresPerHour,
    int WindDirectionDegrees);