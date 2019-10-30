using System;
using System.Text.Json;

namespace WeatherAttack.Contracts.Dtos.Weather.Request
{
    [Serializable]
    public sealed class CoordinatesRequestDto
    {
        //[JsonProperty(PropertyName = "lon")]
        //[JsonProperty(Name = "Name")]
        public string Longitude { get; set; }

        //[JsonProperty(PropertyName = "lat")]
        public string Latitude { get; set; }
    }
}