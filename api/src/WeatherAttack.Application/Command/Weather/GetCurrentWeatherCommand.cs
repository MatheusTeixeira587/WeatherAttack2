using Valit;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Domain.Entities;
using WeatherAttack.Domain.Notifications;

namespace WeatherAttack.Application.Command.Weather
{
    public sealed class GetCurrentWeatherCommand : CommandBase
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public CurrentWeather Result { get; set; }

        protected override bool Validate()
        {
            var result = ValitRules<GetCurrentWeatherCommand>
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
