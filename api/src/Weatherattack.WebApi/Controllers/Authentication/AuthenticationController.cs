using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Interfaces;
using WeatherAttack.Security.Commands;

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
            var result = await Task.Run(() =>
            {
                return LoginActionHandler.ExecuteAction(command);               
            });

            if (result.IsValid)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
