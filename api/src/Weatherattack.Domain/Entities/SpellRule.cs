using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WeatherAttack.Domain.Enums;

namespace WeatherAttack.Domain.Entities
{
    public sealed class SpellRule : EntityBase
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

        public long SpellId { get; private set; }

        public int Value { get; private set; }

        public Operator Operator { get; private set; }

        public WeatherCondition WeatherCondition { get; private set; }

        private static readonly IReadOnlyCollection<long> StormIdList = new ReadOnlyCollection<long>(
                new List<long>()
                {
                    200, 201, 202, 210, 211, 212, 221, 230, 231, 232
                });

        public bool Assert(CurrentWeather weather)
        {
            switch (WeatherCondition)
            {
                case WeatherCondition.Rain:
                    return AssertOperator(weather.Rain.Volume);
                case WeatherCondition.Storm:
                    return AssertStorm(weather.Weather);
                case WeatherCondition.Wind:
                    return AssertOperator(weather.Wind.Speed);
                case WeatherCondition.Temperature:
                    return AssertOperator(weather.Main.Temperature);
                default:
                    return false;
            }
        }

        private bool AssertOperator(double value)
        {
            switch (Operator)
            {
                case Operator.EQUAL:
                    return value == Value;
                case Operator.HIGHER_OR_EQUAL_TO:
                    return value >= Value;
                case Operator.HIGHER_THAN:
                    return value > Value;
                case Operator.LOWER_OR_EQUAL_TO:
                    return value <= Value;
                case Operator.LOWER_THAN:
                    return value < Value;
                default:
                    return false;
            }
        }

        private bool AssertStorm(List<Weather.Weather> weather)
        {
            return weather.Any(s => StormIdList.Contains(s.Id));
        }
    }
}
