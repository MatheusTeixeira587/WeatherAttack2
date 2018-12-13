
namespace Weatherattack.Application.Contracts.Dtos.User.Response
{
    public class UserRequestDto
    {
        public string Name { get;  set; }

        public string Email { get;  set; }

        public string Username { get;  set; }

        public string Password { get; set; }

        public UserRequestDto(string name, string email, string username, string password)
        {
            Name = name;
            Email = email;
            Username = username;
            Password = password;
        }

    }
}
