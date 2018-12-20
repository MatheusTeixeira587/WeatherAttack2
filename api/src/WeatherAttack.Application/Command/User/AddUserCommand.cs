using WeatherAttack.Application.Contracts.Command;
using WeatherAttack.Application.Contracts.Dtos.User.Response;

namespace WeatherAttack.Application.Command.User
{
    public class AddUserCommand : CommandBase
    {
        public UserResponseDto User { get; set; }

        private IActionHandler<AddUserCommand> Handler { get; }

        public override void Execute() => Handler.HandleAction(this);
        
    }
}
