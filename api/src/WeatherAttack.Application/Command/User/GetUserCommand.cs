
using Valit;
using WeatherAttack.Application.Contracts.Command;
using WeatherAttack.Application.Contracts.Dtos.User.Response;
using WeatherAttack.Domain.Notifications;

namespace WeatherAttack.Application.Command.User
{
    public class GetUserCommand : CommandBase
    {
        public UserResponseDto Result { get; set; }

        protected override void Validate()
        {
            var result = ValitRules<GetUserCommand>
                .Create()
                .Ensure(c => c.Id, _ => _
                    .IsGreaterThan(0)
                        .WithMessage(WeatherAttackNotifications.Command.InvalidId))
                .For(this)
                .Validate();

            AddNotification(WeatherAttackNotifications.GetNotification(result.ErrorMessages));
        }
    }
}
