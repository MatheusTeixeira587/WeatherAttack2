using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.Spell.Request;
using WeatherAttack.Contracts.Mapper;
using WeatherAttack.Domain.Contracts;
using Entities = WeatherAttack.Domain.Entities;

namespace WeatherAttack.Application.Command.Spell.Handlers
{
    public class AddSpellActionHandler : IActionHandler<AddSpellCommand>
    {
        public AddSpellActionHandler(ISpellRepository context, IMapper<Entities.Spell, SpellRequestDto, SpellRequestDto> mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        private ISpellRepository Context { get; }

        private IMapper<Entities.Spell, SpellRequestDto, SpellRequestDto> Mapper { get; }

        public AddSpellCommand ExecuteAction(AddSpellCommand command)
        {
            if (!command.IsValid)
                return command;

            var spell = Mapper.ToEntity(command.Spell);
            spell.Element.ToString();
            if (spell.IsValid)
            {
                if (spell.IsNew)
                    Context.Add(spell);
                else
                    Context.Edit(spell);

                Context.Save();
            }

            command.AddNotification(spell.Notifications);

            return command;
        }
    }
}
