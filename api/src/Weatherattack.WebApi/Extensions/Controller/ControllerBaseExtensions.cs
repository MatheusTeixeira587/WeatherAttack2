using Microsoft.AspNetCore.Mvc;
using WeatherAttack.Contracts.Command;

namespace WeatherAttack.WebApi.Extensions.Controller
{
    public static class ControllerBaseExtensions
    {
        public static IActionResult Response(this ControllerBase that, CommandBase command)
        {
            if (command.IsValid)
            {
                return that.Ok(command);
            }
            else
            {
                return that.BadRequest(command);
            }
        }
    }
}
