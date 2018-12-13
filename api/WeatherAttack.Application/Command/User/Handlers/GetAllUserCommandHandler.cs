using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weatherattack.Application.Command.User;
using Weatherattack.Infra.Repositories;

namespace WeatherAttack.Application.Command.User.Handlers
{
    public class GetAllUserCommandHandler
    {
        private UserRepository Context { get; }

        public GetAllUsersCommand HandleAction(GetAllUsersCommand command)
        {
            var users = Context.GetAll();

            if (users.Count() != 0)
                command.Users = users;

            return command;
        }
    }
}
