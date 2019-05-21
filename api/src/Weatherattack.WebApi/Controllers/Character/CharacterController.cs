using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherAttack.Application.Command.Character;
using WeatherAttack.Contracts.Command;
using WeatherAttack.WebApi.Extensions.Controller;

namespace WeatherAttack.WebApi.Controllers.Character
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class CharacterController : ControllerBase
    {
        private IActionHandler<GetCharacterCommand> GetCharacterActionHandler { get; }

        public CharacterController(IActionHandler<GetCharacterCommand> getCharacterActionHandler)
        {
            GetCharacterActionHandler = getCharacterActionHandler;
        }

        [HttpGet("{Id:min(1)}")]
        public async Task<IActionResult> Get([FromRoute] GetCharacterCommand command)
        {
            return await Task.Run(() =>
            {
                return this.Response(GetCharacterActionHandler.ExecuteAction(command));
            });
        }
    }
}