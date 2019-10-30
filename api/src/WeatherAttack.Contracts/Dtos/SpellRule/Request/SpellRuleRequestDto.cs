using WeatherAttack.Contracts.Dtos.Spell.Request;

namespace WeatherAttack.Contracts.Dtos.SpellRule.Request
{
    public sealed class SpellRuleRequestDto
    {
        public long Id { get; set; }

        public long SpellId { get; set; }

        public int Value { get; set; }

        public byte Operator { get; set; }

        public byte WeatherCondition { get; set; }
    }
}
