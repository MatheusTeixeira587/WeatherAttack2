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
        private IActionHandler<LoginCommand> LoginActionHandler { get; }

        public AuthenticationController(IActionHandler<LoginCommand> loginActionHandler)
        {
            LoginActionHandler = loginActionHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
            => await Task.Run(()
                => GetResponse(LoginActionHandler.ExecuteAction(command)));
    }
}
