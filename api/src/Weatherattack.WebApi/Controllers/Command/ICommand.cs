using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weatherattack.WebApi.Controllers.User.Command
{
    public interface ICommand
    {
        void Execute();
    }
}
