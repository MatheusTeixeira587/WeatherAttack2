using System.Threading.Tasks;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.Character;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Notifications;

namespace WeatherAttack.Application.Command.Character.Handlers
{
    public sealed class GetCharacterActionHandler : IActionHandlerAsync<GetCharacterCommand>
    {
        private ICharacterRepository Context { get; }

        public GetCharacterActionHandler(ICharacterRepository context)
        {
            Context = context;
        }

        public async Task<GetCharacterCommand> ExecuteActionAsync(GetCharacterCommand command)
        {
            var result = await Context
                .FindAsync(c => c.UserId == command.Id, c => new CharacterDto()
                {
                    Id = c.Id,
                    Losses = c.Losses,
                    Battles = c.Battles,
                    Wins = c.Wins,
                    UserId = c.UserId,
                    Medals = c.Medals,
                    HealthPoints = c.HealthPoints,
                    ManaPoints = c.ManaPoints
                });

            if (result is null)
                command.AddNotification(WeatherAttackNotifications.Character.InvalidCharacter);

            command.Result = result;

            return command;
        }
    }
}
