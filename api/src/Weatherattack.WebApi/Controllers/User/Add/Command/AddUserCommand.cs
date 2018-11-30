using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weatherattack.WebApi.Controllers.User.Dto;

namespace Weatherattack.WebApi.Controllers.User.Command
{
    public class AddUserCommand : ICommand
    {

        private UserRequestDto User {get;set;}

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
