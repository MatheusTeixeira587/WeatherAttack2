namespace WeatherAttack.Domain.Entities.Weather
{
    public class Weather
    {
        public long Id { get; private set; }

        public string Main { get; private set; }

        public string Description { get; private set; }

        public string Icon { get; private set; }
    }
}
