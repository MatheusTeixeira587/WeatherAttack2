using System.Linq;
using System.Threading.Tasks;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Notifications;

namespace WeatherAttack.Application.Command.User.Handlers
{
    public class DeleteUserActionHandler : IActionHandlerAsync<DeleteUserCommand>
    {
        private IUserRepository Context { get; }

        public DeleteUserActionHandler(IUserRepository context)
        {
            Context = context;
        }

        public async Task<DeleteUserCommand> ExecuteActionAsync(DeleteUserCommand entity)
        {
            var user = await Context
                .FindAsync(entity.Id);

            if (user != null)
                Context.Delete(user);
            else
                entity.AddNotification(WeatherAttackNotifications.Command.InvalidId);

            return entity;
        }
    }
}
