using System.Threading.Tasks;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Notifications;

namespace WeatherAttack.Application.Command.Spell.Handlers
{
    public class DeleteSpellActionHandler : IActionHandlerAsync<DeleteSpellCommand>
    {
        private ISpellRepository Context { get; }

        public async Task<DeleteSpellCommand> ExecuteActionAsync(DeleteSpellCommand command)
        {
            var result = await Context
                .FindAsync(command.Id);

            if (result is null)
                command.AddNotification(WeatherAttackNotifications.Spell.NotFound);
            else
                Context.Delete(result);

            Context.SaveAsync();

            return command;
        }
    }
}
