using WeatherAttack.Contracts.Dtos.Character;
using WeatherAttack.Contracts.Mapper;

namespace WeatherAttack.Application.Mapper.Character
{
    public class CharacterEntityMapper : IMapper<Domain.Entities.Character, CharacterDto, CharacterDto>
    {
        public CharacterDto ToDto(Domain.Entities.Character entity)
        {
            return new CharacterDto()
            {
                Id = entity.Id,
                Losses = entity.Losses,
                Battles = entity.Battles,
                Wins = entity.Wins,
                UserId = entity.UserId,
                Medals = entity.Medals,
                HealthPoints = entity.HealthPoints,
                ManaPoints = entity.ManaPoints
            };
        }

        public Domain.Entities.Character ToEntity(CharacterDto request)
        {
            return new Domain.Entities.Character
            (
                request.Id,
                request.UserId,
                request.HealthPoints,
                request.ManaPoints,
                request.Battles,
                request.Wins,
                request.Losses,
                request.Medals
            );
        }
    }
}
