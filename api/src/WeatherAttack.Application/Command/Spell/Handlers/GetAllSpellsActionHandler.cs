using System.Linq;
using WeatherAttack.Application.Contracts.Command;
using WeatherAttack.Application.Contracts.Dtos.Spell.Request;
using WeatherAttack.Application.Mapper;
using WeatherAttack.Domain.Contracts;

namespace WeatherAttack.Application.Command.Spell.Handlers
{
    public class GetAllSpellsActionHandler : IActionHandler<GetAllSpellsCommand>
    {
        public GetAllSpellsActionHandler(ISpellRepository context, IMapper<Domain.Entities.Spell, SpellRequestDto, SpellRequestDto> mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        private ISpellRepository Context { get; }

        private IMapper<Domain.Entities.Spell, SpellRequestDto, SpellRequestDto> Mapper { get; }

        public GetAllSpellsCommand ExecuteAction(GetAllSpellsCommand command)
        {
            var result = Context.GetAll()?
                .Select(s => Mapper.ToDto(s))
                .ToList();

            command.Result = result;

            return command;
        }
    }
}
