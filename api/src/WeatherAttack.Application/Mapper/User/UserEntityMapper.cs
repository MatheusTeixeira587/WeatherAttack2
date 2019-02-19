using WeatherAttack.Application.Contracts.Dtos.User.Request;
using WeatherAttack.Application.Contracts.Dtos.User.Response;
using Entities = WeatherAttack.Domain.Entities;

namespace WeatherAttack.Application.Mapper.User
{
    public class UserEntityMapper : IMapper<Entities.User, UserRequestDto, UserResponseDto>
    {
        public UserResponseDto ToDto(Entities.User user)
        {
            return new UserResponseDto()
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.Username,
                Character = user.Character
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
