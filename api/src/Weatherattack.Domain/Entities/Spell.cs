using System.Collections.Generic;
using Valit;
using WeatherAttack.Domain.Enums;
using WeatherAttack.Domain.Notifications;
using ValidationRules = WeatherAttack.Domain.EntityValidation.Rules.Rules;

namespace WeatherAttack.Domain.Entities
{
    public class Spell : EntityBase
    {
        public Spell(long id, string name, int baseDamage, int baseManaCost, Element element) : base(id)
        {
            Name = name;
            BaseDamage = baseDamage;
            BaseManaCost = baseManaCost;
            Element = element;
        }

        public Spell(long id, string name, int baseDamage, int baseManaCost, Element element, List<SpellRule> rules) : base(id)
        {
            Name = name;
            BaseDamage = baseDamage;
            BaseManaCost = baseManaCost;
            Element = element;
            Rules = rules;
        }

        public string Name { get; private set; }

        public int BaseDamage { get; private set; }

        public int BaseManaCost { get; private set; }

        public Element Element { get; private set; }

        public List<SpellRule> Rules { get; private set; } = new List<SpellRule>();

        protected override bool Validate()
        {
            var result = ValitRules<Spell>
                .Create()
                .Ensure(s => s.BaseDamage, _=>_
                    .IsPositive()
                        .WithMessage(WeatherAttackNotifications.Spell.MustBePositive)
                    .IsLessThanOrEqualTo(ValidationRules.Spell.BaseDamage.MaxDamage)
                        .WithMessage(WeatherAttackNotifications.Spell.ShouldBeLowerThan)
                    .IsGreaterThanOrEqualTo(ValidationRules.Spell.BaseDamage.MinDamage)
                        .WithMessage(WeatherAttackNotifications.Spell.ShouldBeHigherThan))
                .Validate();

            AddNotification(WeatherAttackNotifications.Get(result.ErrorMessages));

            return base.Validate();
        }
    }
}
