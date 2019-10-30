using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherAttack.Application.Command.Character;
using WeatherAttack.Contracts.Command;

namespace WeatherAttack.WebApi.Controllers.Character
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public sealed class CharacterController : BaseController
    {
        private IActionHandlerAsync<GetCharacterCommand> GetCharacterActionHandler { get; }

        public CharacterController(IActionHandlerAsync<GetCharacterCommand> getCharacterActionHandler)
            => GetCharacterActionHandler = getCharacterActionHandler;

        [HttpGet("{Id:min(1)}")]
        public async Task<IActionResult> GetAsync([FromRoute] GetCharacterCommand command)
            => GetResponse(await GetCharacterActionHandler.ExecuteActionAsync(command));
    }
}