using System.Linq;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Notifications;

namespace WeatherAttack.Application.Command.User.Handlers
{
    public class DeleteUserActionHandler : IActionHandler<DeleteUserCommand>
    {
        private IUserRepository Context { get; }

        public DeleteUserActionHandler(IUserRepository context)
        {
            Context = context;
        }

        public DeleteUserCommand ExecuteAction(DeleteUserCommand entity)
        {
            var user = Context
                .Find(u => u.Id == entity.Id)
                .SingleOrDefault();

            if (user != null)
                Context.Delete(user);
            else
                entity.AddNotification(WeatherAttackNotifications.Command.InvalidId);

            return entity;
        }
    }
}
