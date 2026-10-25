namespace WebApi.Controllers.Transport;

public sealed record RealtimeWeatherResponse(
	string Location,
	DateTimeOffset Time,
	double TemperatureCelsius,
	int RelativeHumidityPercent,
	double ApparentTemperatureCelsius,
	bool IsDay,
	int WeatherCode,
	double WindSpeedKilometresPerHour,
	int WindDirectionDegrees);