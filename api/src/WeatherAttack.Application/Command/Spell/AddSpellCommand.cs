using System;
using System.Collections.Generic;
using Valit;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.Spell.Request;
using WeatherAttack.Domain.Enums;
using WeatherAttack.Domain.Notifications;

namespace WeatherAttack.Application.Command.Spell
{
    public class AddSpellCommand : CommandBase
    {
        public SpellRequestDto Spell { get; set; }

        protected override bool Validate()
        {
            HashSet<byte> operatorValues = new HashSet<byte>((byte[])Enum.GetValues(typeof(Operator)));
            HashSet<byte> weatherConditionValues = new HashSet<byte>((byte[])Enum.GetValues(typeof(WeatherCondition)));
            object possibleToConvert = false;

            var result = ValitRules<SpellRequestDto>
                .Create()
                .Ensure(s => s.Element, _ => _
                    .Satisfies(s => Enum.TryParse(typeof(Element), s.ToString(), out possibleToConvert))
                    .WithMessage(WeatherAttackNotifications.Command.InvalidValue))
                .For(Spell)
                .Ensure(s => s.Rules, _ => _
                    .Satisfies(
                        r => r.TrueForAll(
                            sr => operatorValues.Contains(sr.Operator)
                                && weatherConditionValues.Contains(sr.WeatherCondition)))
                                .WithMessage(WeatherAttackNotifications.Command.InvalidValue))
                .Validate();

            AddNotification(result.ErrorMessages);          

            return base.Validate();
        }
    }
}
