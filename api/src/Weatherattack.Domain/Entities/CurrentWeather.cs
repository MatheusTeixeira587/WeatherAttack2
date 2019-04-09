using WeatherEntities = WeatherAttack.Domain.Entities.Weather;

namespace WeatherAttack.Domain.Entities
{
    public class CurrentWeather : EntityBase
    {
        public WeatherEntities.Coordinates Coordinates { get; private set; }

        public WeatherEntities.Weather Weather { get; private set; }

        public WeatherEntities.Main Main { get; private set; }

        public WeatherEntities.Wind Wind { get; private set; }

        public WeatherEntities.Rain Rain { get; private set; }
    }
}
