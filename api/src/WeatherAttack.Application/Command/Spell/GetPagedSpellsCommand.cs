using System.Collections.Generic;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.Spell.Response;

namespace WeatherAttack.Application.Command.Spell
{
    public class GetPagedSpellsCommand : PagedCommand
    {
        public IEnumerable<SpellResponseDto> Result;
    }
}
