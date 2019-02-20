using System;
using Valit;
using WeatherAttack.Application.Contracts.Command;
using WeatherAttack.Application.Contracts.Dtos.Spell.Request;
using WeatherAttack.Domain.Enums;
using WeatherAttack.Domain.Notifications;

namespace WeatherAttack.Application.Command.Spell
{
    public class AddSpellCommand : CommandBase
    {
        public SpellRequestDto Spell { get; set; }

        protected override bool Validate()
        {
            var result = ValitRules<SpellRequestDto>
                .Create()
                .Ensure(s => s.Element, _ => _
                    .Satisfies(s => Enum.IsDefined(typeof(Element), s))
                    .WithMessage(WeatherAttackNotifications.Command.InvalidValue))
                .For(Spell)
                .Ensure(s => s.Rules, _ => _
                    .Satisfies(
                        r => r.TrueForAll(
                            sr => Enum.IsDefined(typeof(Operator), sr.Operator)
                                && Enum.IsDefined(typeof(WeatherCondition), sr.WeatherCondition)))
                                .WithMessage(WeatherAttackNotifications.Command.InvalidValue))
                .Validate();

            AddNotification(result.ErrorMessages);          

            return base.Validate();
        }
    }
}
