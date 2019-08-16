using System.Security.Claims;
using WeatherAttack.Application.Command.User;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.User.Response;
using WeatherAttack.Contracts.Interfaces;
using SignalRHub = Microsoft.AspNetCore.SignalR.Hub;

namespace WeatherAttack.Hub.Hubs
{
    public abstract class HubBase : SignalRHub, IHub
    {
        private IActionHandler<GetUserCommand> GetUserActionHandler { get; }

        public virtual long GetUserId()
        {
            return int.Parse(
                Context.User
                    .FindFirst(claim =>
                        claim.Type == ClaimTypes.PrimarySid)
                    .Value);
        }

        public virtual UserResponseDto GetUser()
        {
            var id = GetUserId();

            var user = GetUserActionHandler.ExecuteAction(new GetUserCommand() { Id = id }).Result;
            user.Email = null;

            return user;
        }

        protected HubBase(IActionHandler<GetUserCommand> getUserActionHandler)
        {
            GetUserActionHandler = getUserActionHandler;
        }
    }
}
