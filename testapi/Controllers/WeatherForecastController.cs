using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace testapi.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        }
        [HttpPost("merhaba")]
        public IActionResult Merhaba(string selam)
        {
            if (selam == "31")
            {
                return Ok(selam);
            }
            if (string.IsNullOrEmpty(selam))
            {
                return BadRequest("eksik veri");
            }
            else
            {
                return BadRequest("desteklenmeyen veri türü");
            }
        }
    }
}