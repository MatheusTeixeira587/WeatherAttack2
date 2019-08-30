using System.Security.Claims;
using System.Threading.Tasks;
using WeatherAttack.Application.Command.User;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.User.Response;
using WeatherAttack.Contracts.Interfaces;
using SignalRHub = Microsoft.AspNetCore.SignalR.Hub;

namespace WeatherAttack.Hub.Hubs
{
    public abstract class HubBase : SignalRHub, IHub
    {
        private IActionHandlerAsync<GetUserCommand> GetUserActionHandler { get; }

        public virtual long GetUserId()
        {
            return int.Parse(
                Context.User
                    .FindFirst(claim =>
                        claim.Type == ClaimTypes.PrimarySid)
                    .Value);
        }

        public async virtual Task<UserResponseDto> GetUser()
        {
            var id = GetUserId();

            var command = await GetUserActionHandler.ExecuteActionAsync(new GetUserCommand() { Id = id });
            command.Result.Email = null;
            return command.Result;
        }

        protected HubBase(IActionHandlerAsync<GetUserCommand> getUserActionHandler)
        {
            GetUserActionHandler = getUserActionHandler;
        }
    }
}
