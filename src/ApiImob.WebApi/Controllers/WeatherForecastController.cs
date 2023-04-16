using ApiImob.Domain.Interfaces;
using ApiImob.Infra.Connections;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace ApiImob.WebApi.Controllers
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

        private readonly IImoveisAppService _imoveisAppService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IImoveisAppService imoveisAppService)
        {
            _logger = logger;
            _imoveisAppService = imoveisAppService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
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
    }
}