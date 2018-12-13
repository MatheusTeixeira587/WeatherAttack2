using System;
using Weatherattack.Application.Contracts.Command;
using weatherattack2.src.Domain.Entities;

namespace WeatherAttack.Application.Contracts.Command
{
    public class CommandBase : EntityBase, ICommand
    {
        public virtual void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
