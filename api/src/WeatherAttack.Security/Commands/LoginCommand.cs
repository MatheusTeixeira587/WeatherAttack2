using System.IdentityModel.Tokens.Jwt;
using WeatherAttack.Contracts.Command;

namespace WeatherAttack.Security.Commands
{
    public class LoginCommand : CommandBase
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }
    }
}
