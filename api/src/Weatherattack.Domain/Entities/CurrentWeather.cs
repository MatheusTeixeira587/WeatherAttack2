using System.Collections.Generic;
using WeatherEntities = WeatherAttack.Domain.Entities.Weather;

namespace WeatherAttack.Domain.Entities
{
    public class CurrentWeather : EntityBase
    {
        public CurrentWeather() { }

        public CurrentWeather(
            long id, 
            string cityName, 
            WeatherEntities.Coordinates coordinates, 
            List<WeatherEntities.Weather> weather, 
            WeatherEntities.Main main, 
            WeatherEntities.Wind wind,
            WeatherEntities.CountryInfo countryInfo,
            WeatherEntities.Rain rain) : base(id)
        {
            CityName = cityName;
            Coordinates = coordinates;
            Weather = weather;
            Main = main;
            Wind = wind;
            CountryInfo = countryInfo;
            Rain = rain;
        }

        public WeatherEntities.Coordinates Coordinates { get; private set; }

        public List<WeatherEntities.Weather> Weather { get; private set; }

        public WeatherEntities.Main Main { get; private set; }

        public WeatherEntities.Wind Wind { get; private set; }

        public WeatherEntities.Rain Rain { get; private set; }

        public WeatherEntities.CountryInfo CountryInfo { get; private set; }

        public string CityName { get; private set; }
    }
}
