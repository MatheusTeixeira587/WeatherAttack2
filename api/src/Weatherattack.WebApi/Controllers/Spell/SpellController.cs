using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherAttack.Application.Command.Spell;
using WeatherAttack.Contracts.Command;

namespace WeatherAttack.WebApi.Controllers.Spell
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class SpellController : BaseController
    {
        private IActionHandlerAsync<AddSpellCommand> AddSpellActionHandler { get; }

        private IActionHandlerAsync<GetSpellCommand> GetSpellActionHandler { get; }

        private IActionHandlerAsync<DeleteSpellCommand> DeleteSpellActionHandler { get; }

        private IActionHandlerAsync<GetSpellsForLocationCommand> GetSpellsForLocationActionHandler { get; }

        private IActionHandlerAsync<GetPagedSpellsCommand> GetPagedSpellActionHandler { get; }

        [HttpGet("Page-{Page:min(1)}"), Authorize]
        public async Task<IActionResult> Get([FromRoute]GetPagedSpellsCommand command, long page)
        {
            command.PageNumber = page;
            return GetResponse(await GetPagedSpellActionHandler.ExecuteActionAsync(command));
        }

        [HttpGet("{Id:min(1)}"), Authorize]
        public async Task<IActionResult> Get([FromRoute] GetSpellCommand command, long id)
        {
            command.Id = id;
            return GetResponse(await GetSpellActionHandler.ExecuteActionAsync(command));
        }

        [HttpPut]
        public async Task<IActionResult> AddAsync([FromBody] AddSpellCommand command)
            => GetResponse(await AddSpellActionHandler.ExecuteActionAsync(command));

        [HttpDelete("{Id:min(1)}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteSpellCommand command, long id)
            => GetResponse(await DeleteSpellActionHandler.ExecuteActionAsync(command));

        [HttpPost("[action]"), Authorize]
        public async Task<IActionResult> GetSpellsForLocation([FromBody] GetSpellsForLocationCommand command)
           => GetResponse(await GetSpellsForLocationActionHandler.ExecuteActionAsync(command));

        public SpellController(IActionHandlerAsync<AddSpellCommand> addSpellActionHandler,
            IActionHandlerAsync<GetSpellCommand> getSpellActionHandler,
            IActionHandlerAsync<DeleteSpellCommand> deleteSpellActionHandler,
            IActionHandlerAsync<GetSpellsForLocationCommand> getSpellsForLocationActionHandler,
            IActionHandlerAsync<GetPagedSpellsCommand> getPagedSpellActionHandler)
        {
            AddSpellActionHandler = addSpellActionHandler;
            GetSpellActionHandler = getSpellActionHandler;
            DeleteSpellActionHandler = deleteSpellActionHandler;
            GetSpellsForLocationActionHandler = getSpellsForLocationActionHandler;
            GetPagedSpellActionHandler = getPagedSpellActionHandler;
        }
    }
}
