using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WeatherAttack.Contracts.Dtos.Weather.Request
{
    [Serializable]
    public class CurrentWeatherRequestDto
    {
        [JsonProperty(PropertyName = "coord")]
        public CoordinatesRequestDto Coordinates { get; set; }

        [JsonProperty(PropertyName = "weather")]
        public List<WeatherRequestDto> Weather { get; set; }

        [JsonProperty(PropertyName = "main")]
        public MainRequestDto Main { get; set; }

        [JsonProperty(PropertyName = "wind")]
        public WindRequestDto Wind { get; set; }

        [JsonProperty(PropertyName = "rain")]
        public RainRequestDto Rain { get; set; }

        [JsonProperty(PropertyName = "sys")]
        public CountryInfoRequestDto CountryInfo { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string CityName { get; set; }
    }
}
