using Entity = WeatherAttack.Domain.Entities;

namespace WeatherAttack.Application.Contracts.Dtos.User.Request
{
    public class UserRequestDto
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }


        public UserRequestDto(string name, string email, string username, string password)
        {
            Name = name;
            Email = email;
            Username = username;
            Password = password;
        }

        public Entity.User ToEntity()
        {
            var user = new Entity.User(Name,Email,Username);
            user.SetPassword(Password);
            return user;
        }
    }
}
