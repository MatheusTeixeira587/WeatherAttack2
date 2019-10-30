using System.Collections.Generic;
using Valit;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.Spell.Response;
using WeatherAttack.Domain.Notifications;

namespace WeatherAttack.Application.Command.Spell
{
    public sealed class GetSpellsForLocationCommand : CommandBase
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public IEnumerable<SpellResponseDto> Result { get; set; }

        protected override bool Validate()
        {
            var result = ValitRules<GetSpellsForLocationCommand>
                .Create()
                .Ensure(c => c.Latitude, _ => _
                    .IsNumber()
                        .WithMessage(WeatherAttackNotifications.Command.InvalidValue))
                .Ensure(c => c.Longitude, _ => _
                    .IsNumber()
                        .WithMessage(WeatherAttackNotifications.Command.InvalidValue))
                .For(this)
                .Validate();

            AddNotification(result.ErrorMessages);

            return base.Validate();
        }
    }
}
