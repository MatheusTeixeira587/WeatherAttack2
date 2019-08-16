using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Notifications;

namespace WeatherAttack.Application.Command.Spell.Handlers
{
    public class DeleteSpellActionHandler : IActionHandler<DeleteSpellCommand>
    {
        private ISpellRepository Context { get; }

        public DeleteSpellCommand ExecuteAction(DeleteSpellCommand command)
        {
            var result = Context
                .Find(c => c.Id == command.Id)
                .SingleOrDefault();

            if (result is null)
                command.AddNotification(WeatherAttackNotifications.Spell.NotFound);
            else
                Context.Delete(result);

            Context.Save();

            return command;
        }
    }
}
