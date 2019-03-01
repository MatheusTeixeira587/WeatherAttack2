using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Security.Commands;
using WeatherAttack.WebApi.Extensions.Controller;

namespace WeatherAttack.WebApi.Controllers.Authorization
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IActionHandler<LoginCommand> LoginActionHandler { get; }

        public AuthenticationController(IActionHandler<LoginCommand> loginActionHandler)
        {
            LoginActionHandler = loginActionHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            return await Task.Run(() =>
            {
                return this.Response(LoginActionHandler.ExecuteAction(command));
            });          
        }
    }
}
