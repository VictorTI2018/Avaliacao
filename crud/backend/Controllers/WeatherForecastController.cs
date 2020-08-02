
using System.Data;
using backend.Models;
using backend.Repositories;
using backend.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : Controller
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

        [HttpGet]
        public object Get()
        {
           ClientRepository clientRepo = new ClientRepository();
           DataTable data = clientRepo.find(3);
           return data.Rows[0]["first_name"];
        }

        [HttpPost]
        public IActionResult Post([FromBody]Client value)
        {
            return Json(new {
                Response = "OK",
                Data = value
            });
        }
    }
}
