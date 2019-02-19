using System.Collections.Generic;
using WeatherAttack.Application.Contracts.Dtos.SpellRule.Request;

namespace WeatherAttack.Application.Contracts.Dtos.Spell.Request
{
    public class SpellRequestDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int BaseDamage { get; set; }

        public int BaseManaCost { get; set; }

        public byte Element { get; set; }

        public List<SpellRuleRequestDto> Rules { get; set; } = new List<SpellRuleRequestDto>();
    }
}
