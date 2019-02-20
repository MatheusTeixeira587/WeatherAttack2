using Valit;
using WeatherAttack.Domain.Enums;

namespace WeatherAttack.Domain.Entities
{
    public class SpellRule : EntityBase
    {
        public SpellRule(long id, Spell spell, int value, Operator @operator, WeatherCondition weatherCondition) : base(id)
        {
            Spell = spell;
            Value = value;
            Operator = @operator;
            WeatherCondition = WeatherCondition;
        }

        public Spell Spell { get; private set; }

        public int Value { get; private set; }

        public Operator Operator { get; private set; }

        public WeatherCondition WeatherCondition { get; private set; }

        protected override bool Validate()
        {
            return base.Validate();
        }
    }
}
