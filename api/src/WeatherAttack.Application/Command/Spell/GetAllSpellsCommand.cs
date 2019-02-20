using System.Collections.Generic;
using WeatherAttack.Application.Contracts.Command;
using WeatherAttack.Application.Contracts.Dtos.Spell.Request;

namespace WeatherAttack.Application.Command.Spell
{
    public class GetAllSpellsCommand : CommandBase
    {
        public ICollection<SpellRequestDto> Result;
    }
}
