using WeatherAttack.Contracts.Dtos.Weather.Request;

namespace WeatherAttack.Contracts.Interfaces
{
    public interface IOpenWeatherMapService
    {
        CurrentWeatherRequestDto GetCurrentWeatherByCoordinates(double latitude, double longitude);
    }
}
