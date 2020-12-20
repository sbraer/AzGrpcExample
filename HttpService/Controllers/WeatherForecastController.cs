using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HttpService.Controllers
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
		private readonly IHelper _helper;

		public WeatherForecastController(ILogger<WeatherForecastController> logger, IHelper helper)
		{
			_logger = logger;
			_helper = helper;
		}

		[HttpGet]
		public ActionResult<IEnumerable<WeatherForecast>> Get()
		{
			if (_helper.Counter++ % 3 == 0)
			{
				return StatusCode(500);
			}
			else
			{
				var rng = new Random();
				return Enumerable.Range(1, 5).Select(index => new WeatherForecast
				{
					Date = DateTime.Now.AddDays(index),
					TemperatureC = rng.Next(-20, 55),
					Summary = Summaries[rng.Next(Summaries.Length)]
				})
				.ToArray();
			}
		}
	}
}
