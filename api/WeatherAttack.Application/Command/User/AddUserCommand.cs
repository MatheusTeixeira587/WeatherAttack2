using System;
using Weatherattack.Application.Contracts.Command;
using Weatherattack.Application.Contracts.Dtos.User.Response;
using WeatherAttack.Application.Contracts.Command;

namespace Weatherattack.Application.Command.User
{
    public class AddUserCommand : CommandBase
    {
        private UserRequestDto User {get;set;}

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
