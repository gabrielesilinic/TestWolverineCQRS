using Microsoft.AspNetCore.Mvc;
using Wolverine;
using TestWolverineCQRS.Commands;
using TestWolverineCQRS.Queries;

namespace TestWolverineCQRS.Controllers
{
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMessageBus _bus;

        public WeatherForecastController(IMessageBus bus)
        {
            _bus = bus;
        }

        [HttpGet("GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await _bus.InvokeAsync<IEnumerable<WeatherForecast>>(new GetWeatherForecastQuery());
        }

        [HttpPost("SetFavoritePlace")]
        public async Task<IActionResult> SetFavoritePlace([FromBody] SetFavoritePlaceCommand request)
        {
            await _bus.InvokeAsync(request);
            return Ok(new { message = "Favorite place set!" });
        }

        [HttpGet("GetFavoritePlace")]
        public async Task<GetFavoritePlaceQueryResponse> GetFavoritePlace()
        {
            return await _bus.InvokeAsync<GetFavoritePlaceQueryResponse>(new GetFavoritePlaceQuery());
        }
    }
}
