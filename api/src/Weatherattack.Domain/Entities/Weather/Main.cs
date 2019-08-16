namespace WeatherAttack.Domain.Entities.Weather
{
    public class Main
    {
        public Main(double temperature, double pressure, double humidity)
        {
            Temperature = temperature;
            Pressure = pressure;
            Humidity = humidity;
        }

        public double Temperature { get; private set; }

        public double Pressure { get; private set; }

        public double Humidity { get; private set; }
    }
}
