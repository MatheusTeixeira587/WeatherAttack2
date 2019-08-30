using System.Collections.Generic;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.Spell.Response;

namespace WeatherAttack.Application.Command.Spell
{
    public class GetAllSpellsCommand : CommandBase
    {
        public GetAllSpellsCommand(long id) : base(id) { }

        public ICollection<SpellResponseDto> Result;
    }
}
