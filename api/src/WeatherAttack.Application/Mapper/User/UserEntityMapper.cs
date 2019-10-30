using WeatherAttack.Contracts.Dtos.Character;
using WeatherAttack.Contracts.Dtos.User.Request;
using WeatherAttack.Contracts.Dtos.User.Response;
using WeatherAttack.Contracts.Mapper;
using Entities = WeatherAttack.Domain.Entities;

namespace WeatherAttack.Application.Mapper.User
{
    public sealed class UserEntityMapper : IMapper<Entities.User, UserRequestDto, UserResponseDto>
    {
        IMapper<Entities.Character, CharacterDto, CharacterDto> CharacterMapper { get; }

        public UserEntityMapper(IMapper<Entities.Character, CharacterDto, CharacterDto> characterMapper)
        {
            CharacterMapper = characterMapper;
        }

        public UserResponseDto ToDto(Entities.User user)
        {
            return new UserResponseDto()
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.Username,
                PermissionLevel = user.PermissionLevel,
                Character = user.Character is null ? null : CharacterMapper.ToDto(user.Character)
            };
        }

        public Entities.User ToEntity(UserRequestDto dto)
        {
            var user = new Entities.User(dto.Id, dto.Email, dto.Username);
            user.SetPassword(dto.Password);
            return user;
        }
    }
}
