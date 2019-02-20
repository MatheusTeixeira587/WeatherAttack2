using System.Linq;
using WeatherAttack.Application.Contracts.Command;
using WeatherAttack.Application.Contracts.Dtos.Spell.Request;
using WeatherAttack.Application.Mapper;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Entities;
using WeatherAttack.Domain.Notifications;

namespace WeatherAttack.Application.Command.Spell.Handlers
{
    public class GetSpellActionHandler : IActionHandler<GetSpellCommand>
    {
        public GetSpellActionHandler(ISpellRepository context, IMapper<Domain.Entities.Spell, SpellRequestDto, SpellRequestDto> mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        private ISpellRepository Context { get; }

        private IMapper<Domain.Entities.Spell, SpellRequestDto, SpellRequestDto> Mapper { get; }

        public GetSpellCommand ExecuteAction(GetSpellCommand command)
        {
            var result = Context.FindBy(c => c.Id == command.Id)?
                .Select(c => Mapper.ToDto(c))
                .First();

            if (result == null)
                command.AddNotification(WeatherAttackNotifications.Spell.NotFound);
            else
                command.Result = result;

            return command;
        }
    }
}
