namespace TestWolverineCQRS.Queries
{
    public record GetWeatherForecastQuery();

    public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }

    public class GetWeatherForecastQueryHandler
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild",
            "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public static Task<IEnumerable<WeatherForecast>> Handle(GetWeatherForecastQuery query)
        {
            var forecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                Summaries[Random.Shared.Next(Summaries.Length)]
            ));

            return Task.FromResult(forecast);
        }
    }
}
