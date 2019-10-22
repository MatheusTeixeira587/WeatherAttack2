using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.Spell.Request;
using WeatherAttack.Contracts.Dtos.Spell.Response;
using WeatherAttack.Contracts.Dtos.Weather.Request;
using WeatherAttack.Contracts.Interfaces;
using WeatherAttack.Contracts.Mapper;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Entities;
using Entities = WeatherAttack.Domain.Entities;

namespace WeatherAttack.Application.Command.Spell.Handlers
{
    public class GetSpellsForLocationActionHandler : IActionHandlerAsync<GetSpellsForLocationCommand>
    {
        private IOpenWeatherMapService OpenWeatherMap { get; }

        private IMapper<CurrentWeather, CurrentWeatherRequestDto, CurrentWeatherRequestDto> WeatherMapper { get; }

        private ISpellRepository Context { get; }

        private IMapper<Entities.Spell, SpellRequestDto, SpellResponseDto> SpellMapper { get; }

        

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

            var currentWeather = WeatherMapper.ToEntity(await OpenWeatherMap.GetCurrentWeatherByCoordinates(command.Latitude, command.Longitude));

            command.Result = (await Context.GetAsync(s => s.AssertRules(currentWeather))).Select(e => SpellMapper.ToDto(e));
              
            return command;
        }
    }
}
