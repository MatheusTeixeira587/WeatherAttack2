using Newtonsoft.Json;
using System;

namespace WeatherAttack.Contracts.Dtos.Weather.Request
{
    [Serializable]
    public sealed class WindRequestDto
    {
        [JsonProperty(PropertyName = "speed")]
        public double Speed { get; set; }
    }
}
