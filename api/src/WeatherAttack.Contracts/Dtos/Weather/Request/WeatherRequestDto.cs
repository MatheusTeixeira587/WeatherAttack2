using Newtonsoft.Json;
using System;

namespace WeatherAttack.Contracts.Dtos.Weather.Request
{
    [Serializable]
    public sealed class WeatherRequestDto
    {
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "main")]
        public string Main { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }
    }
}
