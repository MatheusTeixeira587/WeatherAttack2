using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Security.Commands;

namespace WeatherAttack.WebApi.Controllers.Authorization
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private IActionHandlerAsync<LoginCommand> LoginActionHandler { get; }

        public AuthenticationController(IActionHandlerAsync<LoginCommand> loginActionHandler)
            => LoginActionHandler = loginActionHandler;

        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] LoginCommand command)
            => GetResponse(await LoginActionHandler.ExecuteActionAsync(command));
    }
}
