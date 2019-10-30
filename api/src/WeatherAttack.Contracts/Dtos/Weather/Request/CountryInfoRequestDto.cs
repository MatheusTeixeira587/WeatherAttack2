using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAttack.Contracts.Dtos.Weather.Request
{
    [Serializable]
    public sealed class CountryInfoRequestDto
    {
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
    }
}
