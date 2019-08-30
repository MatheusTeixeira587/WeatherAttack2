using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherAttack.Application.Command.Spell;
using WeatherAttack.Contracts.Command;

namespace WeatherAttack.WebApi.Controllers.Spell
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpellController : BaseController
    {
        private IActionHandler<AddSpellCommand> AddSpellActionHandler { get; }

        private IActionHandlerAsync<GetSpellCommand> GetSpellActionHandler { get; }

        private IActionHandler<GetAllSpellsCommand> GetAllSpellsActionHandler { get; }

        private IActionHandlerAsync<DeleteSpellCommand> DeleteSpellActionHandler { get; }

        private IActionHandlerAsync<GetSpellsForLocationCommand> GetSpellsForLocationActionHandler { get; }

        private IActionHandlerAsync<GetPagedSpellsCommand> GetPagedSpellActionHandler { get; }

        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] GetAllSpellsCommand command)
            => await Task.Run(() 
                => GetResponse(GetAllSpellsActionHandler.ExecuteAction(command)));

        [HttpGet("Page-{Page:min(1)}")]
        public async Task<IActionResult> Get([FromRoute]GetPagedSpellsCommand command, long page)
        {
            return await Task.Run(async () =>
            {
                command.PageNumber = page;
                return GetResponse(await GetPagedSpellActionHandler.ExecuteActionAsync(command));
            });
        }

        [HttpGet("{Id:min(1)}")]
        public async Task<IActionResult> Get([FromRoute] GetSpellCommand command, long id)
        {
            return await Task.Run(async () =>
            {
                command.Id = id;
                return GetResponse(await GetSpellActionHandler.ExecuteActionAsync(command));
            });
        }

        [HttpPut]
        public async Task<IActionResult> Add([FromBody] AddSpellCommand command)
            => await Task.Run(()
                => GetResponse(AddSpellActionHandler.ExecuteAction(command)));

        [HttpDelete("{Id:min(1)}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteSpellCommand command, long id)
        => GetResponse(await DeleteSpellActionHandler.ExecuteActionAsync(command));

        [HttpPost("[action]")]
        public async Task<IActionResult> GetSpellsForLocation([FromBody] GetSpellsForLocationCommand command)
        {
            return await Task.Run(async () =>
            {
                return GetResponse(await GetSpellsForLocationActionHandler.ExecuteActionAsync(command));
            });
        }

        public SpellController(IActionHandler<AddSpellCommand> addSpellActionHandler,
            IActionHandler<GetAllSpellsCommand> getAllSpellsActionHandler,
            IActionHandlerAsync<GetSpellCommand> getSpellActionHandler,
            IActionHandlerAsync<DeleteSpellCommand> deleteSpellActionHandler,
            IActionHandlerAsync<GetSpellsForLocationCommand> getSpellsForLocationActionHandler,
            IActionHandlerAsync<GetPagedSpellsCommand> getPagedSpellActionHandler)
        {
            AddSpellActionHandler = addSpellActionHandler;
            GetSpellActionHandler = getSpellActionHandler;
            GetAllSpellsActionHandler = getAllSpellsActionHandler;
            DeleteSpellActionHandler = deleteSpellActionHandler;
            GetSpellsForLocationActionHandler = getSpellsForLocationActionHandler;
            GetPagedSpellActionHandler = getPagedSpellActionHandler;
        }
    }
}
