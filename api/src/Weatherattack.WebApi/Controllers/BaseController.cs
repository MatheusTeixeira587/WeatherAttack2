using Microsoft.AspNetCore.Mvc;
using WeatherAttack.Contracts.Command;

namespace WeatherAttack.WebApi.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        [NonAction]
        protected virtual IActionResult GetResponse(CommandBase command)
        {
            if (command.IsValid)
                return Ok(command);
            else
                return BadRequest(command);
        }
    }
}