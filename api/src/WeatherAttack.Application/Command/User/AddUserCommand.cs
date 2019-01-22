using Valit;
using WeatherAttack.Application.Contracts.Command;
using WeatherAttack.Application.Contracts.Dtos.User.Request;
using WeatherAttack.Domain.Notifications;

namespace WeatherAttack.Application.Command.User
{
    public class AddUserCommand : CommandBase
    {
        public UserRequestDto User { get; set; }

        protected override void Validate()
        {
            var result = ValitRules<AddUserCommand>
                .Create()
                .Ensure(c => c.User, _ => _
                    .Required()
                        .WithMessage(WeatherAttackNotifications.Command.UserIsRequired))
                .For(this)
                .Validate();

            AddNotification(WeatherAttackNotifications.GetNotification(result.ErrorMessages));
        }
    }
}
