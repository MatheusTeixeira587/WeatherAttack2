using System;
using System.Collections.Generic;
using System.Text;
using Valit;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Domain.Notifications;

namespace WeatherAttack.Application.Command.Weather
{
    public class GetCurrentWeatherCommand : CommandBase
    {
        public string Latitude { get; set; }

        public string Longitude { get; set; }

        protected override bool Validate()
        {
            var result = ValitRules<GetCurrentWeatherCommand>
                .Create()
                .Ensure(c => c.Latitude, _ => _
                    .Required()
                        .WithMessage(WeatherAttackNotifications.Command.InvalidValue)
                    .Satisfies(l => !string.IsNullOrEmpty(l))
                        .WithMessage(WeatherAttackNotifications.Command.InvalidValue))
                .Ensure(c => c.Longitude, _ => _
                    .Required()
                        .WithMessage(WeatherAttackNotifications.Command.InvalidValue)
                    .Satisfies(l => !string.IsNullOrEmpty(l))
                        .WithMessage(WeatherAttackNotifications.Command.InvalidValue))
                .Validate();

            AddNotification(result.ErrorMessages);

            return base.Validate();
        }
    }  
}
