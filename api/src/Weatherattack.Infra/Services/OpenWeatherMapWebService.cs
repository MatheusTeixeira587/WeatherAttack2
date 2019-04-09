namespace WeatherAttack.Infra.Services
{
    public class OpenWeatherMapWebService
    {
        private string OpenWeatherMapUrl { get; }

        private string OpenWeatherMapKey { get; }

        public OpenWeatherMapWebService(string openWeatherMapUrl, string openWeatherMapKey)
        {
            OpenWeatherMapKey = openWeatherMapKey;
            OpenWeatherMapUrl = openWeatherMapUrl;
        }

        public void GetCurrentWeatherByCoordinates(string lat, string lon)
        {

        }
    }
}
