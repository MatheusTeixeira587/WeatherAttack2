using System.Threading.Tasks;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Notifications;
using Entities = WeatherAttack.Domain.Entities;

namespace WeatherAttack.Application.Command.User.Handlers
{
    public sealed class DeleteUserActionHandler : IActionHandlerAsync<DeleteUserCommand>
    {
        private IUserRepository Context { get; }

        public DeleteUserActionHandler(IUserRepository context)
        {
            Context = context;
        }

        public async Task<DeleteUserCommand> ExecuteActionAsync(DeleteUserCommand entity)
        {
            var user = await Context
                .FindAsync(entity.Id, e => new Entities.User(e.Id));

            if (user != null)
                Context.Delete(user);
            else
                entity.AddNotification(WeatherAttackNotifications.Command.InvalidId);

            return entity;
        }
    }
}
