using WeatherAttack.Contracts.Command;

namespace WeatherAttack.Security.Commands
{
    public sealed class LoginCommand : CommandBase
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }
    }
}
