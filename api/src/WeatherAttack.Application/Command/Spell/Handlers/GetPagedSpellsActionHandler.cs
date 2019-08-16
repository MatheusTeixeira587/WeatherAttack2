using System.Linq;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.Spell.Request;
using WeatherAttack.Contracts.Mapper;
using WeatherAttack.Domain.Contracts;
using Entities = WeatherAttack.Domain.Entities;

namespace WeatherAttack.Application.Command.Spell.Handlers
{
    public class GetPagedSpellsActionHandler : IActionHandler<GetPagedSpellsCommand>
    {
        private ISpellRepository Context;

        private IMapper<Entities.Spell, SpellRequestDto, SpellRequestDto> Mapper { get; }

        public GetPagedSpellsCommand ExecuteAction(GetPagedSpellsCommand command)
        {
            int skip = (int)(command.PageSize * (command.PageNumber - 1));
            int take = (int)command.PageSize;

            var result = Context
                .Get(skip, take)
                ?.Select(r => Mapper.ToDto(r))
                .ToList();

            if (result is null)
                return command;

            long totalRecords = Context.Count();

            command.PageNumber = (skip + take) / command.PageSize;
            command.PageCount =
                totalRecords / command.PageSize < 1
                    ? 1
                    : totalRecords / command.PageSize;

            command.TotalRecords = totalRecords;

            command.Result = result;

            return command;
        }
    }
}
