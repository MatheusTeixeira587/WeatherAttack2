using Valit;
using WeatherAttack.Application.Contracts.Command;
using WeatherAttack.Application.Contracts.Dtos.User.Request;

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
                    .Required())
                .For(this)
                .Validate();
        }
    }
}
