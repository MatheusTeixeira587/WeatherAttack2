using WeatherAttack.Contracts.Dtos.Weather.Request;
using WeatherAttack.Contracts.Mapper;
using WeatherAttack.Domain.Entities.Weather;
using Entities = WeatherAttack.Domain.Entities;

namespace WeatherAttack.Application.Mapper.Weather
{
    public sealed class WeatherEntityMapper : IMapper<Entities.Weather.Weather, WeatherRequestDto, WeatherRequestDto>
    {
        public WeatherRequestDto ToDto(Entities.Weather.Weather entity)
        {
            return new WeatherRequestDto()
            {
                Description = entity.Description,
                Icon = entity.Icon,
                Id = entity.Id,
                Main = entity.Main
            };
        }

        public Entities.Weather.Weather ToEntity(WeatherRequestDto request)
        {
            return new Entities.Weather.Weather(
                request.Id, 
                request.Main, 
                request.Description, 
                request.Icon
            );
        }
    }
}
