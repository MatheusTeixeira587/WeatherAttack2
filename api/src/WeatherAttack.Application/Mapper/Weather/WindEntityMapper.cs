using System;
using System.Collections.Generic;
using System.Text;
using WeatherAttack.Contracts.Dtos.Weather.Request;
using WeatherAttack.Contracts.Mapper;
using WeatherAttack.Domain.Entities.Weather;

namespace WeatherAttack.Application.Mapper.Weather
{
    public class WindEntityMapper : IMapper<Wind, WindRequestDto, WindRequestDto>
    {
        public WindRequestDto ToDto(Wind entity)
        {
            return new WindRequestDto()
            {
                Speed = entity.Speed
            };
        }

        public Wind ToEntity(WindRequestDto request)
        {
            return new Wind(request.Speed);
        }
    }
}
