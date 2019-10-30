namespace WeatherAttack.Domain.Entities.Weather
{
    public sealed class Coordinates
    {
        public Coordinates(string longitude, string latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }

        public Coordinates()
        {
        }

        public string Longitude { get; private set; }

        public string Latitude { get; private set; }
    }
}
