using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Application.OpenWeather.Queries.Validations
{
    public class OpenWeatherErrorResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; }
    }
}
