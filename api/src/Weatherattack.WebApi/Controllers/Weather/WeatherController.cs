using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherAttack.Application.Command.Weather;
using WeatherAttack.Contracts.Command;

namespace WeatherAttack.WebApi.Controllers.Weather
{
    [Route("api/[controller]")]
    [ApiController, AllowAnonymous]
    public sealed class WeatherController : BaseController
    {
        private IActionHandlerAsync<GetCurrentWeatherCommand> GetCurrentWeatherActionHandler { get; }

        public WeatherController(IActionHandlerAsync<GetCurrentWeatherCommand> getCurrentWeatherActionHandler)
            => GetCurrentWeatherActionHandler = getCurrentWeatherActionHandler;

        [HttpPost]
        public async Task<IActionResult> GetAsync([FromBody] GetCurrentWeatherCommand command)
            => GetResponse(await GetCurrentWeatherActionHandler.ExecuteActionAsync(command));
    }
}