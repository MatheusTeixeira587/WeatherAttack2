
using System.Linq;
using Weatherattack.Application.Contracts.Command;
using WeatherAttack.Application.Command.User.Handlers;
using WeatherAttack.Application.Contracts.Command;

namespace Weatherattack.Application.Command.User
{
    public class GetAllUsersCommand : CommandBase
    {
        private GetAllUserCommandHandler Handler { get; }

        public IQueryable Result { get; set; }

        public override void Execute()
        {
            Handler.HandleAction(this);
        }
    }
}
