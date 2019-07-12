using System.Collections.Generic;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.Spell.Request;

namespace WeatherAttack.Application.Command.Spell
{
    public class GetAllSpellsCommand : CommandBase
    {
        public GetAllSpellsCommand(long id, long page) : base(id) {
            this.Page = page;
        }

        public long Page;

        public ICollection<SpellRequestDto> Result;
    }
}
