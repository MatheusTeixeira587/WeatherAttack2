using Newtonsoft.Json;
using System;

namespace WeatherAttack.Contracts.Dtos.Weather.Request
{
    [Serializable]
    public sealed class RainRequestDto
    {
        [JsonProperty(PropertyName = "3h")]
        public double Volume { get; set; }
    }
}
