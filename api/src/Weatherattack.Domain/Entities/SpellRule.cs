using Valit;
using WeatherAttack.Domain.Enums;

namespace WeatherAttack.Domain.Entities
{
    public class SpellRule : EntityBase
    {
        public SpellRule(long id, long spellId, int value, Operator @operator, WeatherCondition weatherCondition) : base(id)
        {
            SpellId = spellId;
            Value = value;
            Operator = @operator;
            WeatherCondition = WeatherCondition;
        }

        public SpellRule(long id, int value, Operator @operator, WeatherCondition weatherCondition) : base(id)
        {
            Value = value;
            Operator = @operator;
            WeatherCondition = WeatherCondition;
        }

        public Spell Spell { get; private set; }

        public long SpellId { get; set; }

        public int Value { get; private set; }

        public Operator Operator { get; private set; }

        public WeatherCondition WeatherCondition { get; private set; }

        protected override bool Validate()
        {
            return !HasNotification();
        }
    }
}
