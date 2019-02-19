using System.Linq;
using WeatherAttack.Application.Contracts.Command;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Notifications;
using Entities = WeatherAttack.Domain.Entities;

namespace WeatherAttack.Application.Command.User.Handlers
{
    public class DeleteUserActionHandler : IActionHandler<DeleteUserCommand>
    {
        private IRepository<Entities.User> Context { get; }

        public DeleteUserActionHandler(IRepository<Entities.User> context)
        {
            Context = context;
        }

        public DeleteUserCommand ExecuteAction(DeleteUserCommand entity)
        {
            var user = Context.FindBy(u => u.Id == entity.Id)
                        .FirstOrDefault();

            if (user != null)
                Context.Delete(user);
            else
                entity.AddNotification(WeatherAttackNotifications.Command.InvalidId);

            return entity;
        }
    }
}
