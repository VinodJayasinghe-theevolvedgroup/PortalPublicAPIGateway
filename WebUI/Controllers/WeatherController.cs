using Application.OpenWeather.Queries.GetWeatherForecasts;
using Infrasructure.Identity.Authorization.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class WeatherController : ApiController
    {
        [HttpGet("anyone/{location}")]
        public async Task<IEnumerable<WeatherForecast>> Anyone(string location)
        {
            return await Mediator.Send(new GetWeatherForecastsQuery { Location = location });
        }

        [HttpGet("only-authenticated/{location}")]
        [Authorize]
        public async Task<IEnumerable<WeatherForecast>> OnlyAuthenticated(string location)
        {
            return await Mediator.Send(new GetWeatherForecastsQuery { Location = location });

        }

        [HttpGet("only-clients/{location}")]
        [Authorize(Policy = Policies.OnlyClients)]
        public async Task<IEnumerable<WeatherForecast>> OnlyEmployees(string location)
        {
            return await Mediator.Send(new GetWeatherForecastsQuery { Location = location });

        }

        [HttpGet("only-subclients/{location}")]
        [Authorize(Policy = Policies.OnlySubClients)]
        public async Task<IEnumerable<WeatherForecast>> OnlyManagers(string location)
        {
            return await Mediator.Send(new GetWeatherForecastsQuery { Location = location });

        }

        [HttpGet("only-third-parties/{location}")]
        [Authorize(Policy = Policies.OnlyThirdParties)]
        public async Task<IEnumerable<WeatherForecast>> OnlyThirdParties(string location)
        {
            return await Mediator.Send(new GetWeatherForecastsQuery { Location = location });

        }
    }
}
