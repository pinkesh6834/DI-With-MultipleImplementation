using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DI_With_MultipleImplementation.Services;
using DI_With_MultipleImplementation.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DI_With_MultipleImplementation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IService serviceOne;
        private readonly IService serviceTwo;
        private readonly IService serviceThree;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ServiceResolver service)
        {
            this.serviceOne = service("one");
            this.serviceTwo = service("two");
            this.serviceThree = service("three");

            _logger = logger;
        }

        [HttpGet]
        public WeatherForecast Get()
        {
            _logger.LogInformation("Called WeatherForecastController : Get");
            return this.serviceOne.GetWeathData();
        }

        [HttpGet]
        [Route("GetServiceTwo")]
        public WeatherForecast GetServiceTwo()
        {
            return this.serviceTwo.GetWeathData();
        }

        [HttpGet]
        [Route("GetServiceThree")]
        public WeatherForecast GetServiceThree()
        {
            return this.serviceThree.GetWeathData();
        }
    }
}
