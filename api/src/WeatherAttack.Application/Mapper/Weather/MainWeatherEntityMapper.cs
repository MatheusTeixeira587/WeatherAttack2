using WeatherAttack.Contracts.Dtos.Weather.Request;
using WeatherAttack.Contracts.Mapper;
using WeatherAttack.Domain.Entities.Weather;

namespace WeatherAttack.Application.Mapper.Weather
{
    public sealed class MainWeatherEntityMapper : IMapper<Main, MainRequestDto, MainRequestDto>
    {
        public MainRequestDto ToDto(Main entity)
        {
            return new MainRequestDto()
            {
                Humidity = entity.Humidity,
                Pressure = entity.Pressure,
                Temperature = entity.Temperature
            };
        }

        public Main ToEntity(MainRequestDto request)
        {
            return new Main(request.Temperature, request.Pressure, request.Humidity);         
        }
    }
}
