using System.Linq;
using System.Threading.Tasks;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.Spell.Request;
using WeatherAttack.Contracts.Dtos.Spell.Response;
using WeatherAttack.Contracts.Dtos.SpellRule.Request;
using WeatherAttack.Contracts.Mapper;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Notifications;

namespace WeatherAttack.Application.Command.Spell.Handlers
{
    public sealed class GetSpellActionHandler : IActionHandlerAsync<GetSpellCommand>
    {
        public GetSpellActionHandler(ISpellRepository context)
        {
            Context = context;
        }

        private ISpellRepository Context { get; }

        public async Task<GetSpellCommand> ExecuteActionAsync(GetSpellCommand command)
        {
            var result = await Context
                .FindAsync(command.Id, s => new SpellResponseDto()
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

            if (result is null)
                command.AddNotification(WeatherAttackNotifications.Spell.NotFound);
            else
                command.Result = result;

            return command;
        }
    }
}
