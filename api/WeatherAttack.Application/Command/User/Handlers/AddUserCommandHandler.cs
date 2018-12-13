using Weatherattack.Application.Command.User;
using WeatherAttack.Domain.Contracts;

namespace WeatherAttack.Application.Command.User.Handlers
{
    public class AddUserCommandHandler
    {
        private IUserRepository Context { get; }

        public AddUserCommand HandleAction(AddUserCommand command)
        {
            var user = command.User;

            return command;
        }
    }
}
