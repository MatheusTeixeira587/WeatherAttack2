using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.User.Response;

namespace WeatherAttack.Application.Command.User
{
    public sealed class GetUserCommand : CommandBase
    {
        public UserResponseDto Result { get; set; }
    }
}
