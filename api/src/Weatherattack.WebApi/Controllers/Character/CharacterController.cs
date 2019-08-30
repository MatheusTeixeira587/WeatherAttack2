using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherAttack.Application.Command.Character;
using WeatherAttack.Contracts.Command;

namespace WeatherAttack.WebApi.Controllers.Character
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class CharacterController : BaseController
    {
        private IActionHandler<GetCharacterCommand> GetCharacterActionHandler { get; }

        public CharacterController(IActionHandler<GetCharacterCommand> getCharacterActionHandler)
        => GetCharacterActionHandler = getCharacterActionHandler;

        [HttpGet("{Id:min(1)}")]
        public async Task<IActionResult> Get([FromRoute] GetCharacterCommand command)
            => await Task.Run(() => GetResponse(GetCharacterActionHandler.ExecuteAction(command)));
    }
}