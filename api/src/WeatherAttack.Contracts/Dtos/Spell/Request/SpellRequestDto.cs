using System.Collections.Generic;
using WeatherAttack.Contracts.Dtos.SpellRule.Request;

namespace WeatherAttack.Contracts.Dtos.Spell.Request
{
    public sealed class SpellRequestDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int BaseDamage { get; set; }

        public int BaseManaCost { get; set; }

        public byte Element { get; set; }

        public List<SpellRuleRequestDto> Rules { get; set; }
    }
}
