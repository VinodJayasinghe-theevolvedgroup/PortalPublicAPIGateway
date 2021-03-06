using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OpenWeather.Queries.GetWeatherForecasts
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public decimal Temp { get; set; }
        public decimal FeelsLike { get; set; }
        public decimal TempMin { get; set; }
        public decimal TempMax { get; set; }
    }
}
