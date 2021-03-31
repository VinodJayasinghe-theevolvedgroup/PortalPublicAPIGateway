using Application.Common.Exceptions;
using Application.Common.Model;
using Application.Enums;
using Application.OpenWeather.Queries.Response;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OpenWeather.Queries.GetWeatherForecasts
{
    public class GetWeatherForecastsQuery : IRequest<IEnumerable<WeatherForecast>>
    {
        public string Location { get; set; }

        public class GetWeatherForecastsQueryHandler : IRequestHandler<GetWeatherForecastsQuery, IEnumerable<WeatherForecast>>
        {
            private readonly IHttpClientFactory _httpFactory;
            private readonly OpenWeatherConfig _openWeatherConfig;

            public GetWeatherForecastsQueryHandler(IOptions<OpenWeatherConfig> opts, IHttpClientFactory httpFactory)
            {
                _openWeatherConfig = opts.Value;
                _httpFactory = httpFactory;
            }
         
            public async Task<IEnumerable<WeatherForecast>> Handle(GetWeatherForecastsQuery request, CancellationToken cancellationToken)
            {
                string url = $"https://api.openweathermap.org/data/2.5/{_openWeatherConfig.Resource}" +
                                $"?appid={_openWeatherConfig.ApiKey}" +
                                $"&q={request.Location}" +
                                $"&units={Measure.Metric}";

                var forecasts = new List<WeatherForecast>();

                var client = _httpFactory.CreateClient("OpenWeatherClient");
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonOpts = new JsonSerializerOptions { IgnoreNullValues = true, PropertyNameCaseInsensitive = true };
                    var contentStream = await response.Content.ReadAsStreamAsync();
                    var openWeatherResponse = await JsonSerializer.DeserializeAsync<OpenWeatherResponse>(contentStream, jsonOpts);
                    foreach (var forecast in openWeatherResponse.Forecasts)
                    {
                        forecasts.Add(new WeatherForecast
                        {
                            Date = new DateTime(forecast.Dt),
                            Temp = forecast.Temps.Temp,
                            FeelsLike = forecast.Temps.FeelsLike,
                            TempMin = forecast.Temps.TempMin,
                            TempMax = forecast.Temps.TempMax,
                        });
                    }

                    return await Task.FromResult(forecasts);
                }
                else
                {
                    throw new ExceptionHandler(response.StatusCode, "Error response from OpenWeatherApi: " + response.ReasonPhrase);
                }
            }
        }
    }
}
