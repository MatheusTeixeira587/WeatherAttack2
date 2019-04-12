using Newtonsoft.Json;
using System;

namespace WeatherAttack.Contracts.Dtos.Weather.Request
{
    [Serializable]
    public class CoordinatesRequestDto
    {
        [JsonProperty(PropertyName = "lon")]
        public string Longitude { get; set; }

        [JsonProperty(PropertyName = "lat")]
        public string Latitude { get; set; }
    }
}
