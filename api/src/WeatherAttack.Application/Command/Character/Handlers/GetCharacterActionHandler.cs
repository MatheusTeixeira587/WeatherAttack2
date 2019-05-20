using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Notifications;

namespace WeatherAttack.Application.Command.Character.Handlers
{
    public class GetCharacterActionHandler : IActionHandler<GetCharacterCommand>
    {
        private ICharacterRepository Context { get; }

        public GetCharacterActionHandler(ICharacterRepository context)
        {
            Context = context;
        }

        public GetCharacterCommand ExecuteAction(GetCharacterCommand command)
        {
            var result = Context.FindBy(c => c.UserId == command.Id).SingleOrDefault();

            if (result == null)
                command.AddNotification(WeatherAttackNotifications.Character.InvalidCharacter);

            command.Result = result;

            return command;
        }
    }
}
