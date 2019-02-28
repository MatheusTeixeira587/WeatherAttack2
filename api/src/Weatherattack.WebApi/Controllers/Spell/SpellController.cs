using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherAttack.Application.Command.Spell;
using WeatherAttack.Contracts.Command;

namespace WeatherAttack.WebApi.Controllers.Spell
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpellController : ControllerBase
    {
        private IActionHandler<AddSpellCommand> AddSpellActionHandler { get; }

        private IActionHandler<GetSpellCommand> GetSpellActionHandler { get; }

        private IActionHandler<GetAllSpellsCommand> GetAllSpellsActionHandler { get; }

        private IActionHandler<DeleteSpellCommand> DeleteSpellActionHandler { get; }

        [HttpGet]
        public async Task<GetAllSpellsCommand> Get([FromRoute] GetAllSpellsCommand command)
        {
            return await Task.Run(() => 
            {
                return GetAllSpellsActionHandler.ExecuteAction(command);
            });
        }

        [HttpGet("{Id:min(1)}")]
        public async Task<GetSpellCommand> Get([FromRoute] GetSpellCommand command, long id)
        {
            return await Task.Run(() =>
            {
                command.Id = id;

                return GetSpellActionHandler.ExecuteAction(command);
            });
        }

        [HttpPut]
        public async Task<AddSpellCommand> Add([FromBody] AddSpellCommand command)
        {
            return await Task.Run(() =>
            {
                return AddSpellActionHandler.ExecuteAction(command);
            });
        }

        [HttpDelete("{Id:min(1)}")]
        public async Task<DeleteSpellCommand> Delete([FromRoute] DeleteSpellCommand command, long id)
        {
            return await Task.Run(() => 
            {
                command.Id = id;

                return DeleteSpellActionHandler.ExecuteAction(command);
            });
        }

        public SpellController(IActionHandler<AddSpellCommand> addSpellActionHandler,
            IActionHandler<GetSpellCommand> getSpellActionHandler,
            IActionHandler<GetAllSpellsCommand> getAllSpellsActionHandler,
            IActionHandler<DeleteSpellCommand> deleteSpellActionHandler)
        {
            AddSpellActionHandler = addSpellActionHandler;
            GetSpellActionHandler = getSpellActionHandler;
            GetAllSpellsActionHandler = getAllSpellsActionHandler;
            DeleteSpellActionHandler = deleteSpellActionHandler;
        }
    }
}
