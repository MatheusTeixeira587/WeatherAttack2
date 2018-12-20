
using System.Linq;
using WeatherAttack.Application.Contracts.Command;

namespace WeatherAttack.Application.Command.User
{
    public class GetAllUsersCommand : CommandBase
    {
        private IActionHandler<GetAllUsersCommand> Handler { get; }

        public IQueryable Result { get; set; }

        public override void Execute() => Handler.HandleAction(this);
        
    }
}
