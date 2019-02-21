using WeatherAttack.Application.Contracts.Command;
using WeatherAttack.Application.Contracts.Dtos.User.Response;

namespace WeatherAttack.Application.Command.User
{
    public class GetUserCommand : CommandBase
    {
        public UserResponseDto Result { get; set; }
    }
}
