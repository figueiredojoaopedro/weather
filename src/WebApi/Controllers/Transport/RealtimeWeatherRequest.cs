using System.ComponentModel.DataAnnotations;

namespace WebApi.Controllers.Transport;

public sealed record RealtimeWeatherRequest
{
    [Required, MinLength(1), RegularExpression(@".*\S.*")]
    public required string Location { get; init; }
}