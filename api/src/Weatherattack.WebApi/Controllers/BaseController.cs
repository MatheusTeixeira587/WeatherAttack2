using Microsoft.AspNetCore.Mvc;
using WeatherAttack.Contracts.Command;

namespace WeatherAttack.WebApi.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        [NonAction]
        protected virtual IActionResult GetResponse<T>(T command) where T : CommandBase
        {
            if (!command.HasNotification())
                return Ok(command);
            else
                return BadRequest(command);
        }
    }
}