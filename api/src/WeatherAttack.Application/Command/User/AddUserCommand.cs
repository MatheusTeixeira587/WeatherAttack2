using Valit;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.User.Request;
using WeatherAttack.Domain.Notifications;

namespace WeatherAttack.Application.Command.User
{
    public sealed class AddUserCommand : CommandBase
    {
        public UserRequestDto User { get; set; }

        protected override bool Validate()
        {
            var result = ValitRules<AddUserCommand>
                .Create()
                .Ensure(c => c.User, _ => _
                    .Required()
                        .WithMessage(WeatherAttackNotifications.Command.UserIsRequired))
                .For(this)
                .Validate();

            AddNotification(WeatherAttackNotifications.Get(result.ErrorMessages));

            return Notifications.Count == 0;
        }
    }
}
