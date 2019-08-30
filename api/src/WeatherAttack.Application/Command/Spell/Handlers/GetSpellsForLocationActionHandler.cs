using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.Spell.Request;
using WeatherAttack.Contracts.Dtos.Spell.Response;
using WeatherAttack.Contracts.Dtos.Weather.Request;
using WeatherAttack.Contracts.Interfaces;
using WeatherAttack.Contracts.Mapper;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Entities;
using WeatherAttack.Domain.Enums;
using Entities = WeatherAttack.Domain.Entities;

namespace WeatherAttack.Application.Command.Spell.Handlers
{
    public class GetSpellsForLocationActionHandler : IActionHandlerAsync<GetSpellsForLocationCommand>
    {
        private IOpenWeatherMapService OpenWeatherMap { get; }

        private IMapper<CurrentWeather, CurrentWeatherRequestDto, CurrentWeatherRequestDto> WeatherMapper { get; }

        private ISpellRepository Context { get; }

        private IMapper<Entities.Spell, SpellRequestDto, SpellResponseDto> SpellMapper { get; }

        private static readonly IReadOnlyCollection<long> StormIdList = new ReadOnlyCollection<long>(
                new List<long>()
                {
                    200, 201, 202, 210, 211, 212, 221, 230, 231, 232
                });

        public GetSpellsForLocationActionHandler(IOpenWeatherMapService openWeatherMap, IMapper<CurrentWeather, CurrentWeatherRequestDto, CurrentWeatherRequestDto> weatherMapper, ISpellRepository context, IMapper<Entities.Spell, SpellRequestDto, SpellResponseDto> spellMapper)
        {
            OpenWeatherMap = openWeatherMap;
            WeatherMapper = weatherMapper;
            Context = context;
            SpellMapper = spellMapper;
        }

        public async Task<GetSpellsForLocationCommand> ExecuteActionAsync(GetSpellsForLocationCommand command)
        {
            if (!command.IsValid)
                return command;

            var weatherResponse = await OpenWeatherMap
                .GetCurrentWeatherByCoordinates(command.Latitude, command.Longitude);

            var currentWeather = WeatherMapper
                .ToEntity(weatherResponse);
                   
            command.Result = Context
                .Get()
                .Where(s => AssertRules(s.Rules, currentWeather))
                ?.Select(s => SpellMapper.ToDto(s))
                .ToList();

            return command;
        }

        private bool AssertRules(ICollection<SpellRule> rules, CurrentWeather weather)
        {
            return rules.All(r =>
            {
                switch (r.WeatherCondition)
                {
                    case WeatherCondition.Rain:
                        return AssertOperator(r, weather.Rain.Volume);
                    case WeatherCondition.Storm:
                        return AssertStorm(r, weather.Weather);
                    case WeatherCondition.Wind:
                        return AssertOperator(r, weather.Wind.Speed);
                    case WeatherCondition.Temperature:
                        return AssertOperator(r, weather.Main.Temperature);
                    default:
                        return false;
                }
            });
        }

        private bool AssertOperator(SpellRule rule, double value)
        {
            switch (rule.Operator)
            {
                case Operator.EQUAL:
                    return value == rule.Value;
                case Operator.HIGHER_OR_EQUAL_TO:
                    return value >= rule.Value;
                case Operator.HIGHER_THAN:
                    return value > rule.Value;
                case Operator.LOWER_OR_EQUAL_TO:
                    return value <= rule.Value;
                case Operator.LOWER_THAN:
                    return value < rule.Value;
                default:
                    return false;
            }
        }

        private bool AssertStorm(SpellRule rule, List<Entities.Weather.Weather> weather)
        {
            return weather.Any(s => StormIdList.Contains(s.Id));
        }
    }
}
