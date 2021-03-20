using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI_With_MultipleImplementation.Services
{
    public interface IService
    {
        public WeatherForecast GetWeathData();
    }
}
