using System;
using Weatherattack.Application.Contracts.Command;
using WeatherAttack.Domain.Entities;

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
