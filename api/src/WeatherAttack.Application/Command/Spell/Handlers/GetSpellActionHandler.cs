using System.Linq;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.Spell.Request;
using WeatherAttack.Contracts.Mapper;
using WeatherAttack.Domain.Contracts;
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
