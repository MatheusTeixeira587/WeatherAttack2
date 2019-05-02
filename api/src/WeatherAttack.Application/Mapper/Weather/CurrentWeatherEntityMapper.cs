using System;
using WeatherAttack.Contracts.Dtos.Weather.Request;
using WeatherAttack.Contracts.Mapper;
using Entities = WeatherAttack.Domain.Entities;
using WeatherAttack.Domain.Entities.Weather;
using System.Linq;

namespace WeatherAttack.Application.Mapper.Weather
{
    public class CurrentWeatherEntityMapper : IMapper<Entities.CurrentWeather, CurrentWeatherRequestDto, CurrentWeatherRequestDto>
    {
        private IMapper<Main, MainRequestDto, MainRequestDto> MainMapper { get; }

        private IMapper<Wind, WindRequestDto, WindRequestDto> WindMapper { get; }

        private IMapper<Rain, RainRequestDto, RainRequestDto> RainMapper { get; }

        private IMapper<Coordinates, CoordinatesRequestDto, CoordinatesRequestDto> CoordinatesMapper { get; }

        private IMapper<Entities.Weather.Weather, WeatherRequestDto, WeatherRequestDto> WeatherMapper { get; }

        private IMapper<CountryInfo, CountryInfoRequestDto, CountryInfoRequestDto> CountryMapper { get; }

        public CurrentWeatherEntityMapper(IMapper<Main, MainRequestDto, MainRequestDto> mainMapper, 
            IMapper<Wind, WindRequestDto, WindRequestDto> windMapper, 
            IMapper<Rain, RainRequestDto, RainRequestDto> rainMapper, 
            IMapper<Coordinates, CoordinatesRequestDto, CoordinatesRequestDto> coordinatesMapper, 
            IMapper<Entities.Weather.Weather, WeatherRequestDto, WeatherRequestDto> weatherMapper,
            IMapper<CountryInfo, CountryInfoRequestDto, CountryInfoRequestDto> countryMapper)
        {
            MainMapper = mainMapper;
            WindMapper = windMapper;
            RainMapper = rainMapper;
            CoordinatesMapper = coordinatesMapper;
            WeatherMapper = weatherMapper;
            CountryMapper = countryMapper;
        }

        public CurrentWeatherRequestDto ToDto(Entities.CurrentWeather entity)
        {
            var a = entity.Weather.Select(w => WeatherMapper.ToDto(w)).ToList();
            return new CurrentWeatherRequestDto()
            {
                Main = MainMapper.ToDto(entity.Main),
                Weather = a,
                Wind = WindMapper.ToDto(entity.Wind),
                Rain = RainMapper.ToDto(entity.Rain),
                Coordinates = CoordinatesMapper.ToDto(entity.Coordinates),
                CountryInfo = CountryMapper.ToDto(entity.CountryInfo),
                CityName = entity.CityName
            };
        }

        public Entities.CurrentWeather ToEntity(CurrentWeatherRequestDto request)
        {
            return new Entities.CurrentWeather(
                default(long),
                request.CityName,
                CoordinatesMapper.ToEntity(request.Coordinates),
                request.Weather.Select(w => WeatherMapper.ToEntity(w)).ToList(),
                MainMapper.ToEntity(request.Main),
                WindMapper.ToEntity(request.Wind),
                CountryMapper.ToEntity(request.CountryInfo),
                RainMapper.ToEntity(request.Rain)
            );
        }
    }
}
