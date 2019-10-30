using System;
using WeatherAttack.Contracts.Dtos.Weather.Request;
using WeatherAttack.Contracts.Mapper;
using WeatherAttack.Domain.Entities.Weather;

namespace WeatherAttack.Application.Mapper.Weather
{
    public sealed class RainEntityMapper : IMapper<Rain, RainRequestDto, RainRequestDto>
    {
        public RainRequestDto ToDto(Rain entity)
        {
            return new RainRequestDto()
            {
                Volume = entity.Volume
            };
        }

        public Rain ToEntity(RainRequestDto request)
        {
            return request is null ? null : new Rain(request.Volume);
        }
    }
}
