using System.Collections.Generic;
using System.Linq;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.Spell.Request;
using WeatherAttack.Contracts.Dtos.Spell.Response;
using WeatherAttack.Contracts.Mapper;
using WeatherAttack.Domain.Contracts;

namespace WeatherAttack.Application.Command.Spell.Handlers
{
    public class GetAllSpellsActionHandler : IActionHandler<GetAllSpellsCommand>
    {
        public GetAllSpellsActionHandler(ISpellRepository context, IMapper<Domain.Entities.Spell, SpellRequestDto, SpellResponseDto> mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        private ISpellRepository Context { get; }

        private IMapper<Domain.Entities.Spell, SpellRequestDto, SpellResponseDto> Mapper { get; }

        public GetAllSpellsCommand ExecuteAction(GetAllSpellsCommand command)
        {
            var result = Context
                .Get()?
                .Select(s => Mapper.ToDto(s))
                .ToList();

            command.Result = result;

            return command;
        }
    }
}
