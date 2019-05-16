using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherAttack.Application.Command.Weather;
using WeatherAttack.Contracts.Command;
using WeatherAttack.WebApi.Extensions.Controller;

namespace WeatherAttack.WebApi.Controllers.Weather
{
    [Route("api/[controller]")]
    [ApiController, AllowAnonymous]
    public class WeatherController : ControllerBase
    {
        private IActionHandler<GetCurrentWeatherCommand> GetCurrentWeatherActionHandler { get; }

        public WeatherController(IActionHandler<GetCurrentWeatherCommand> getCurrentWeatherActionHandler)
        {
            GetCurrentWeatherActionHandler = getCurrentWeatherActionHandler;
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Get([FromBody] GetCurrentWeatherCommand command)
        {
            return await Task.Run(() =>
            {
                return this.Response(GetCurrentWeatherActionHandler.ExecuteAction(command));
            });
        }
    }
}