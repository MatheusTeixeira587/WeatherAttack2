
using WeatherAttack.Domain.Entities;

namespace Weatherattack.Application.Contracts.Dtos.User.Response
{
    public class UserResponseDto : EntityBase
    {
        public string Name { get;  set; }

        public string Email { get;  set; }

        public string Username { get;  set; }

        public UserResponseDto(string name, string email, string username)
        {
            Name = name;
            Email = email;
            Username = username;
        }

        public UserResponseDto() { }
    }
}
