using System.Collections.Generic;
using Valit;
using WeatherAttack.Domain.Enums;
using WeatherAttack.Domain.Notifications;
using ValidationRules = WeatherAttack.Domain.EntityValidation.Rules.Rules;

namespace WeatherAttack.Domain.Entities
{
    public class Spell : EntityBase
    {
        public Spell(long id) : base(id) => Id = id;

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
                    .IsLessThanOrEqualTo(ValidationRules.Spell.BaseDamage.MaxDamage)
                        .WithMessage(WeatherAttackNotifications.Spell.BaseDamageShouldBeLowerThan)
                    .IsGreaterThanOrEqualTo(ValidationRules.Spell.BaseDamage.MinDamage)
                        .WithMessage(WeatherAttackNotifications.Spell.BaseDamageShouldBeHigherThan))
                .Ensure(s => s.BaseManaCost, _=>_
                    .IsGreaterThanOrEqualTo(ValidationRules.Spell.BaseManaCost.MinCost)
                        .WithMessage(WeatherAttackNotifications.Spell.BaseManaCostShouldBeHigherThan)
                    .IsLessThanOrEqualTo(ValidationRules.Spell.BaseManaCost.MaxCost)
                        .WithMessage(WeatherAttackNotifications.Spell.BaseManaCostShouldBeLowerThan))
                .Ensure(s => s.Name, _=>_
                    .Required()
                        .WithMessage(WeatherAttackNotifications.Spell.NameIsRequired)
                    .MinLength(ValidationRules.Spell.Name.MinLenght)
                        .WithMessage(WeatherAttackNotifications.Spell.InvalidName)
                    .MaxLength(ValidationRules.Spell.Name.MaxLenght)
                        .WithMessage(WeatherAttackNotifications.Spell.InvalidName))
                .For(this)
                .Validate();

            AddNotification(WeatherAttackNotifications.Get(result.ErrorMessages));

            return base.Validate();
        }
    }
}
