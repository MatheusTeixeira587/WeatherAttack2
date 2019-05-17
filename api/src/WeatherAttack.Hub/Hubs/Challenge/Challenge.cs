using Microsoft.AspNetCore.SignalR;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using WeatherAttack.Application.Command.User;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.User.Response;
using WeatherAttack.Hub.Events.Challenge;
using SignalRHub = Microsoft.AspNetCore.SignalR.Hub;

namespace WeatherAttack.Hub.Hubs.Challenge
{
    public class Challenge : SignalRHub
    {
        private IActionHandler<GetUserCommand> GetUserActionHandler { get; }

        public Challenge(IActionHandler<GetUserCommand> getUserActionHandler)
        {
            GetUserActionHandler = getUserActionHandler;
        }

        [HubMethodName(ChallengeEvents.USER_JOINED_CHANNEL)]
        public async Task JoinChannel(UserResponseDto user)
            => await Clients.All.SendAsync(ChallengeEvents.USER_JOINED_CHANNEL, user);

        [HubMethodName(ChallengeEvents.USER_LEFT_CHANNEL)]
        public async Task QuitChannel(UserResponseDto user)
            => await Clients.All.SendAsync(ChallengeEvents.USER_LEFT_CHANNEL, user);

        public override async Task OnConnectedAsync()
        {
            var id = GetUserId();

            var response = GetUserActionHandler.ExecuteAction(new GetUserCommand() { Id = id });

            await Clients.All.SendAsync(ChallengeEvents.USER_JOINED_CHANNEL, response.Result);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var id = GetUserId();

            var response = GetUserActionHandler.ExecuteAction(new GetUserCommand() { Id = id });

            await Clients.All.SendAsync(ChallengeEvents.USER_LEFT_CHANNEL, response.Result);
        }

        private long GetUserId()
        {
            return int.Parse(
                this.Context.User
                    .FindFirst(claim => 
                        claim.Type == ClaimTypes.PrimarySid)
                    .Value);
        }
    }
}
