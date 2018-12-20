using WeatherAttack.Application.Contracts.Dtos.User.Response;
using WeatherAttack.Application.Contracts.Dtos.User.Request;
using Entity = WeatherAttack.Domain.Entities;    

namespace WeatherAttack.Application.Mapper.User
{
    public class UserEntityMapper : IMapper<Entity.User, UserRequestDto, UserResponseDto>
    {
        public UserResponseDto ToDto(Entity.User user)
        {
            return new UserResponseDto()
            {
                Name = user.Name,
                Email = user.Email,
                Username = user.Username,
            };
        }

        public Entity.User ToEntity(UserRequestDto dto)
        {
            var user = new Entity.User(dto.Name,dto.Email,dto.Username);
            user.SetPassword(dto.Password);

            return user;
        }
    }
}
