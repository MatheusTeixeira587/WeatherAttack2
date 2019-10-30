using System.Threading.Tasks;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.Character;
using WeatherAttack.Contracts.Dtos.User.Response;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Notifications;

namespace WeatherAttack.Application.Command.User.Handlers
{
    public sealed class GetUserActionHandler : IActionHandlerAsync<GetUserCommand>
    {
        private IUserRepository Context { get; }

        public GetUserActionHandler(IUserRepository context)
        {
            Context = context;
        }

        public async Task<GetUserCommand> ExecuteActionAsync(GetUserCommand command)
        {
            var result = await Context
                .FindAsync(command.Id, u => new UserResponseDto()
                {
                    Id = u.Id,
                    Email = u.Email,
                    Username = u.Username,
                    PermissionLevel = u.PermissionLevel,
                    Character = new CharacterDto()
                    {
                        Id = u.Character.Id,
                        Losses = u.Character.Losses,
                        Battles = u.Character.Battles,
                        Wins = u.Character.Wins,
                        UserId = u.Id,
                        Medals = u.Character.Medals,
                        HealthPoints = u.Character.HealthPoints,
                        ManaPoints = u.Character.ManaPoints
                    }
                });

            if (result is null)
                command.AddNotification(WeatherAttackNotifications.User.UserNotFound);
            else
                command.Result = result;

            return command;
        }
    }
}
