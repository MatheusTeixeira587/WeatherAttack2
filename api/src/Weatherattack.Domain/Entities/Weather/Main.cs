namespace WeatherAttack.Domain.Entities.Weather
{
    public class Main
    {
        public Main(double temperature, int pressure, int humidity)
        {
            Temperature = temperature;
            Pressure = pressure;
            Humidity = humidity;
        }

        public double Temperature { get; private set; }

        public int Pressure { get; private set; }

        public int Humidity { get; private set; }
    }
}
