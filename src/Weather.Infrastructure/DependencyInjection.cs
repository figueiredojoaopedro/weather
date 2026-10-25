using Microsoft.Extensions.DependencyInjection;
using Refit;
using Weather.Application.Boundaries;
using Weather.Infrastructure.OpenMeteo;

namespace Weather.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddWeatherInfrastructure(this IServiceCollection services)
    {
        services.AddRefitClient<IOpenMeteoGeocodingApi>()
            .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://geocoding-api.open-meteo.com"));

        services.AddRefitClient<IOpenMeteoForecastApi>()
            .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://api.open-meteo.com"));

        services.AddTransient<IRealtimeWeatherProvider, OpenMeteoWeatherProvider>();
        return services;
    }
}