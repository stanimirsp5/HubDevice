using HubDevice.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HubDevice.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForecastService _weatherForecastService;
    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService)
    {
        _logger = logger;
        _weatherForecastService = weatherForecastService;
    }

    [HttpGet]
    public async Task<IActionResult> GetForecast([FromQuery] string key)
    {
        var redisCustomerList = await _weatherForecastService.GetForecast(key);

        return Ok(redisCustomerList);
    }
    [HttpPost]
    public async Task<IActionResult> AddForecast([FromRoute] string key, [FromRoute] string value)
    {
        await _weatherForecastService.AddForecast(key, value);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> DeleteForecast([FromRoute] string key)
    {
        await _weatherForecastService.DeleteForecast(key);

        return Ok();
    }

}

