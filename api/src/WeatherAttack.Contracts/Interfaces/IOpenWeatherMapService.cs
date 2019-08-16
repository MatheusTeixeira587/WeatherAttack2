using System.Threading.Tasks;
using WeatherAttack.Contracts.Dtos.Weather.Request;

namespace WeatherAttack.Contracts.Interfaces
{
    public interface IOpenWeatherMapService
    {
        Task<CurrentWeatherRequestDto> GetCurrentWeatherByCoordinates(double latitude, double longitude);
    }
}
