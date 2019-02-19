using WeatherAttack.Application.Contracts.Command;
using WeatherAttack.Application.Contracts.Dtos.Spell.Request;
using WeatherAttack.Application.Mapper;
using WeatherAttack.Domain.Contracts;
using Entities = WeatherAttack.Domain.Entities;

namespace WeatherAttack.Application.Command.Spell.Handlers
{
    public class AddSpellActionHandler : IActionHandler<AddSpellCommand>
    {
        private ISpellRepository Context { get; }

        private IMapper<Entities.Spell, SpellRequestDto, SpellRequestDto> Mapper { get; }

        public AddSpellCommand ExecuteAction(AddSpellCommand command)
        {
            var spell = Mapper.ToEntity(command.Spell);

            return null;
        }
    }
}
