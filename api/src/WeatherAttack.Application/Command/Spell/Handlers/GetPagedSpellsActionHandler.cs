using System.Linq;
using System.Threading.Tasks;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.Spell.Request;
using WeatherAttack.Contracts.Dtos.Spell.Response;
using WeatherAttack.Contracts.Mapper;
using WeatherAttack.Domain.Contracts;
using Entities = WeatherAttack.Domain.Entities;

namespace WeatherAttack.Application.Command.Spell.Handlers
{
    public class GetPagedSpellsActionHandler : IActionHandlerAsync<GetPagedSpellsCommand>
    {
        private ISpellRepository Context;

        private IMapper<Entities.Spell, SpellRequestDto, SpellResponseDto> Mapper { get; }

        public GetPagedSpellsActionHandler(ISpellRepository context, IMapper<Entities.Spell, SpellRequestDto, SpellResponseDto> mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public async Task<GetPagedSpellsCommand> ExecuteActionAsync(GetPagedSpellsCommand command)
        {
            int skip = (int)(command.PageSize * (command.PageNumber - 1));
            int take = (int)command.PageSize;

            var result = Context
                .Get(skip, take)
                ?.Select(r => Mapper.ToDto(r))
                .ToList();

            if (result is null)
                return command;


            command.PageNumber = (skip + take) / command.PageSize;

            command.Result = result;

            long totalRecords = await Context.Count();

            command.PageCount =
                totalRecords / command.PageSize < 1
                    ? 1
                    : totalRecords / command.PageSize;

            command.TotalRecords = totalRecords;

            return command;
        }
    }
}
