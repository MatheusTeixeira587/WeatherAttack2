namespace WeatherAttack.Domain.Entities.Weather
{
    public sealed class Weather
    {
        public Weather(long id, string main, string description, string icon)
        {
            Id = id;
            Main = main;
            Description = description;
            Icon = icon;
        }

        public Weather()
        {
        }

        public long Id { get; private set; }

        public string Main { get; private set; }

        public string Description { get; private set; }

        public string Icon { get; private set; }
    }
}
