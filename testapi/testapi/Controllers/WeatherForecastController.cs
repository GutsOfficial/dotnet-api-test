using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using testapi.Entities;

namespace testapi.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        TestContext context = new TestContext();
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
            .ToArray();
        }
        [HttpGet("merhaba")]
        public IActionResult Merhaba()
        {
            return Ok(context.Products.ToList());



        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] UserInput userInput)
        {
            if (ModelState.IsValid)
            {

                var newUser = new User()
                {
                    UserName = userInput.Username,
                    Email = userInput.Email
                };
                var newUser2 = new User()
                {
                    UserName = "userInput.Username",
                    Email = "userInput.Email"
                };
                List<User> users = new List<User> { newUser ,newUser2};


                return Ok(users.ToList());

               // return Ok(newUser);
            }
            else
            {
                return BadRequest(userInput);
            }

           
        }


    }

    public class UserInput
    {
        
        public string Username { get; set; }
        public string Email { get; set; }
    }

    public class User
    {
       
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}