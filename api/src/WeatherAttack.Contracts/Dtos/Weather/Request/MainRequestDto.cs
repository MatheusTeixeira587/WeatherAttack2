using Newtonsoft.Json;
using System;

namespace WeatherAttack.Contracts.Dtos.Weather.Request
{
    [Serializable]
    public class MainRequestDto
    {
        [JsonProperty(PropertyName = "temp")]
        public double Temperature { get; set; }

        [JsonProperty(PropertyName = "pressure")]
        public double Pressure { get; set; }

        [JsonProperty(PropertyName = "humidity")]
        public double Humidity { get; set; }
    }
}
