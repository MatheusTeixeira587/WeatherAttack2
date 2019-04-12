using Newtonsoft.Json;
using System;

namespace WeatherAttack.Contracts.Dtos.Weather.Request
{
    [Serializable]
    public class RainRequestDto
    {
        [JsonProperty(PropertyName = "3h")]
        public double Volume { get; set; }
    }
}
