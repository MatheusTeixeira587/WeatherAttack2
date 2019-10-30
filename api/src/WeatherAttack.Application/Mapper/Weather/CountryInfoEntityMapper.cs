using WeatherAttack.Contracts.Dtos.Weather.Request;
using WeatherAttack.Contracts.Mapper;
using WeatherAttack.Domain.Entities.Weather;

namespace WeatherAttack.Application.Mapper.Weather
{
    public sealed class CountryInfoEntityMapper : IMapper<CountryInfo, CountryInfoRequestDto, CountryInfoRequestDto>
    {
        public CountryInfoRequestDto ToDto(CountryInfo entity)
        {
            return new CountryInfoRequestDto()
            {
                Country = entity.CountryName
            };
        }

        public CountryInfo ToEntity(CountryInfoRequestDto request)
        {
            return new CountryInfo(request.Country);
        }
    }
}
