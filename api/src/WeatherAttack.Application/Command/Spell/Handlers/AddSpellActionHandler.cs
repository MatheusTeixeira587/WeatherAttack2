using System.Collections.Generic;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.Spell.Request;
using WeatherAttack.Contracts.Mapper;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Entities;
using System.Linq;
using Entities = WeatherAttack.Domain.Entities;
using WeatherAttack.Contracts.Dtos.Spell.Response;
using System.Threading.Tasks;

namespace WeatherAttack.Application.Command.Spell.Handlers
{
    public class AddSpellActionHandler : IActionHandlerAsync<AddSpellCommand>
    {
        public AddSpellActionHandler(ISpellRepository context, IMapper<Entities.Spell, SpellRequestDto, SpellResponseDto> mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        private ISpellRepository Context { get; }

        private IMapper<Entities.Spell, SpellRequestDto, SpellResponseDto> Mapper { get; }

        public async Task<AddSpellCommand> ExecuteActionAsync(AddSpellCommand command)
        {
            if (!command.IsValid)
                return command;

            var spell = Mapper.ToEntity(command.Spell);
        
            if (spell.IsValid)
            {
                if (spell.IsNew)
                    await Context.AddAsync(spell);
                else
                    Context.Edit(spell);

                Context.SaveAsync();
            }

            command.AddNotification(spell.Notifications);

            return command;
        }
    }
}
