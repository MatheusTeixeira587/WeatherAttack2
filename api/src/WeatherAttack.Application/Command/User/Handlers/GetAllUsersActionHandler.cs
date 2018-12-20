using System.Linq;
using WeatherAttack.Application.Contracts.Command;
using WeatherAttack.Domain.Contracts;

namespace WeatherAttack.Application.Command.User.Handlers
{
    public class GetAllUsersActionHandler : IActionHandler<GetAllUsersCommand>
    {
        private IUserRepository Context { get; }

        public void HandleAction(GetAllUsersCommand command)
        {
            var users = Context.GetAll();

            if (users.Count() != 0)
                command.Result = users;
        }
    }
}
