using System.Linq;
using Weatherattack.Application.Command.User;
using WeatherAttack.Application.Contracts.Command;
using WeatherAttack.Domain.Contracts;

namespace WeatherAttack.Application.Command.User.Handlers
{
    public class GetAllUserCommandHandler
    {
        private IUserRepository Context { get; }

        public GetAllUsersCommand HandleAction(GetAllUsersCommand command)
        {
            var users = Context.GetAll();

            if (users.Count() != 0)
                command.Result = users;

            return command;
        }
    }
}
