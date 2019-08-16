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
        private IActionHandlerAsync<GetCurrentWeatherCommand> GetCurrentWeatherActionHandler { get; }

        public WeatherController(IActionHandlerAsync<GetCurrentWeatherCommand> getCurrentWeatherActionHandler)
        {
            GetCurrentWeatherActionHandler = getCurrentWeatherActionHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromBody] GetCurrentWeatherCommand command)
        {
            return await Task.Run(async () =>
            {
                return this.Response(await GetCurrentWeatherActionHandler.ExecuteAction(command));
            });
        }
    }
}