using WeatherAttack.Contracts.Dtos.Spell.Request;

namespace WeatherAttack.Contracts.Dtos.SpellRule.Request
{
    public class SpellRuleRequestDto
    {
        public long Id { get; set; }

        public long MagicId { get; set; }

        public SpellRequestDto Spell { get; set; }

        public int Value { get; set; }

        public byte Operator { get; set; }

        public byte WeatherCondition { get; set; }
    }
}
