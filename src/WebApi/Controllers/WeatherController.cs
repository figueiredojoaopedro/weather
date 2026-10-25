
using Microsoft.AspNetCore.Mvc;
using Weather.Application.Usecases;
using WebApi.Controllers.Transport;

namespace WebApi.Controllers;

[ApiController]
[Route("api/weather")]
public sealed class WeatherController(GetRealtimeWeatherUseCase getRealtimeWeather) : ControllerBase
{
  [HttpGet("current")]
  public async Task<ActionResult<RealtimeWeatherResponse>> GetRealtimeWeather(
    [FromQuery] RealtimeWeatherRequest request,
    CancellationToken cancellationToken)
  {
    var weather = await getRealtimeWeather.ExecuteAsync(request.Location, cancellationToken);
    if (weather is null)
    {
      return NotFound();
    }

    return Ok(new RealtimeWeatherResponse(
      weather.Location,
      weather.Time,
      weather.TemperatureCelsius,
      weather.RelativeHumidityPercent,
      weather.ApparentTemperatureCelsius,
      weather.IsDay,
      weather.WeatherCode,
      weather.WindSpeedKilometresPerHour,
      weather.WindDirectionDegrees));
    }
}