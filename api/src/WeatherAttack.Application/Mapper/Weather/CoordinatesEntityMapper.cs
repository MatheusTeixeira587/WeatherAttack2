using System;
using System.Collections.Generic;
using System.Text;
using WeatherAttack.Contracts.Dtos.Weather.Request;
using WeatherAttack.Contracts.Mapper;
using WeatherAttack.Domain.Entities.Weather;

namespace WeatherAttack.Application.Mapper.Weather
{
    public class CoordinatesEntityMapper : IMapper<Coordinates, CoordinatesRequestDto, CoordinatesRequestDto>
    {
        public CoordinatesRequestDto ToDto(Coordinates entity)
        {
            return new CoordinatesRequestDto()
            {
                Latitude = entity.Latitude,
                Longitude = entity.Longitude
            };
        }

        public Coordinates ToEntity(CoordinatesRequestDto request)
        {
            return new Coordinates(request.Longitude, request.Latitude);
        }
    }
}
