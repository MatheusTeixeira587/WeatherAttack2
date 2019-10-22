namespace WeatherAttack.Domain.Entities.Weather
{
    public class Rain
    {
        public Rain(double volume)
        {
            Volume = volume;
        }

        public Rain()
        {
        }

        public double Volume { get; private set; }
    }
}
