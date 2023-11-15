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
            var e2 = _ctx.Database.SqlQueryRaw<Entity1>($"SELECT * FROM Entity1s WHERE Name = {name}").ToList();
            var res1 = e2.First();
            return e1.First();
        }

        [HttpPost("dangerous")]
        public void DeleteFile(string path)
        {
            System.IO.File.Delete(path);
        }

        [HttpPost("dangerous/{id:int}")]
        public void DeleteFile2(string path)
        {
            System.IO.File.Delete(path);
        }

    }
}