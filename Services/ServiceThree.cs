using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI_With_MultipleImplementation.Services
{
    public class ServiceThree : IService
    {
        public WeatherForecast GetWeathData()
        {
            return new WeatherForecast() { Summary = "Response from Service Three" };
        }
    }
}
