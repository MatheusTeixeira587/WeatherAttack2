using System.Linq;
using System.Threading.Tasks;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.Spell.Request;
using WeatherAttack.Contracts.Dtos.Spell.Response;
using WeatherAttack.Contracts.Mapper;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Notifications;

namespace WeatherAttack.Application.Command.Spell.Handlers
{
    public class GetSpellActionHandler : IActionHandlerAsync<GetSpellCommand>
    {
        public GetSpellActionHandler(ISpellRepository context, IMapper<Domain.Entities.Spell, SpellRequestDto, SpellResponseDto> mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        private ISpellRepository Context { get; }

        private IMapper<Domain.Entities.Spell, SpellRequestDto, SpellResponseDto> Mapper { get; }

        public async Task<GetSpellCommand> ExecuteActionAsync(GetSpellCommand command)
        {
            var result = await Context
                .Find(command.Id);

            if (result is null)
                command.AddNotification(WeatherAttackNotifications.Spell.NotFound);
            else
                command.Result = Mapper.ToDto(result);

            return command;
        }
    }
}
