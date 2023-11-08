using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAnalyzerTests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly MyDBContext _ctx;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, MyDBContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("entity/{name}")]
        public Entity1 Get([FromRoute] string name)
        {
            var e1 = _ctx.Database.SqlQuery<Entity1>($"SELECT * FROM Entity1s WHERE Name = {name}").ToList();

            return e1.First();
        }


    }
}