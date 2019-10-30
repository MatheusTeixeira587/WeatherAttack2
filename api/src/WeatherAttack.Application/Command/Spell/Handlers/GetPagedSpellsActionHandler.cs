using System.Linq;
using System.Threading.Tasks;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.Spell.Request;
using WeatherAttack.Contracts.Dtos.Spell.Response;
using WeatherAttack.Contracts.Dtos.SpellRule.Request;
using WeatherAttack.Contracts.Mapper;
using WeatherAttack.Domain.Contracts;
using Entities = WeatherAttack.Domain.Entities;

namespace WeatherAttack.Application.Command.Spell.Handlers
{
    public sealed class GetPagedSpellsActionHandler : IActionHandlerAsync<GetPagedSpellsCommand>
    {
        private ISpellRepository Context;

        public GetPagedSpellsActionHandler(ISpellRepository context)
        {
            Context = context;
        }

        public async Task<GetPagedSpellsCommand> ExecuteActionAsync(GetPagedSpellsCommand command)
        {
            int skip = (int)(command.PageSize * (command.PageNumber - 1));
            int take = (int)(command.PageSize);

            var result = await Context.GetAsync(skip, take, s => new SpellResponseDto()
            {
                Id = s.Id,
                BaseDamage = s.BaseDamage,
                BaseManaCost = s.BaseManaCost,
                Element = s.Element.ToString(),
                Name = s.Name,
                Rules = s.Rules.Select(r => new SpellRuleRequestDto()
                {
                    Id = r.Id,
                    Operator = (byte) r.Operator,
                    WeatherCondition = (byte) r.WeatherCondition,
                    Value = r.Value,
                })
            });

            if (result is null)
                return command;

            command.Result = result;
            await UpdatePaginationInfoAsync(command, skip, take);

            return command;
        }

        private async Task<GetPagedSpellsCommand> UpdatePaginationInfoAsync(GetPagedSpellsCommand command, int skip, int take)
        {
            command.PageNumber = (skip + take) / command.PageSize;

            long totalRecords = await Context.CountAsync();

            command.PageCount =
                totalRecords / command.PageSize < 1
                    ? 1
                    : totalRecords / command.PageSize;

            command.TotalRecords = totalRecords;

            return command;;
        }
    }
}
