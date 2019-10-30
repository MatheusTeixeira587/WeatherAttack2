using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.Spell.Request;
using WeatherAttack.Contracts.Dtos.Spell.Response;
using WeatherAttack.Contracts.Dtos.SpellRule.Request;
using WeatherAttack.Contracts.Dtos.Weather.Request;
using WeatherAttack.Contracts.Interfaces;
using WeatherAttack.Contracts.Mapper;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Entities;
using Entities = WeatherAttack.Domain.Entities;

namespace WeatherAttack.Application.Command.Spell.Handlers
{
    public sealed class GetSpellsForLocationActionHandler : IActionHandlerAsync<GetSpellsForLocationCommand>
    {
        private IOpenWeatherMapService OpenWeatherMap { get; }

        private IMapper<CurrentWeather, CurrentWeatherRequestDto, CurrentWeatherRequestDto> WeatherMapper { get; }

        private ISpellRepository Context { get; }

        public GetSpellsForLocationActionHandler(IOpenWeatherMapService openWeatherMap, IMapper<CurrentWeather, CurrentWeatherRequestDto, CurrentWeatherRequestDto> weatherMapper, ISpellRepository context)
        {
            OpenWeatherMap = openWeatherMap;
            WeatherMapper = weatherMapper;
            Context = context;
        }

        public async Task<GetSpellsForLocationCommand> ExecuteActionAsync(GetSpellsForLocationCommand command)
        {
            if (!command.IsValid)
                return command;

            var currentWeather = WeatherMapper.ToEntity(await OpenWeatherMap.GetCurrentWeatherByCoordinates(command.Latitude, command.Longitude));

            command.Result = await Context.GetAsync(s => s.AssertRules(currentWeather), s => new SpellResponseDto()
            {
                Id = s.Id,
                BaseDamage = s.BaseDamage,
                BaseManaCost = s.BaseManaCost,
                Element = s.Element.ToString(),
                Name = s.Name,
                Rules = s.Rules.Select(r => new SpellRuleRequestDto()
                {
                    Id = r.Id,
                    Operator = (byte)r.Operator,
                    WeatherCondition = (byte)r.WeatherCondition,
                    Value = r.Value,
                })
            });
              
            return command;
        }
    }
}
