using System;
using Weatherattack.Application.Contracts.Command;
using Weatherattack.Application.Contracts.Dtos.User.Response;
using WeatherAttack.Application.Command.User.Handlers;
using WeatherAttack.Application.Contracts.Command;

namespace Weatherattack.Application.Command.User
{
    public class AddUserCommand : CommandBase
    {
        public UserResponseDto User { get; set; }

        private AddUserCommandHandler Handler { get; }

        public override void Execute()
        {
            Handler.HandleAction(this);
        }
    }
}
