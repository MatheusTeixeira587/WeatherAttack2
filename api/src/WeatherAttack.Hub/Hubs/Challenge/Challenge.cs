using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using WeatherAttack.Application.Command.Character;
using WeatherAttack.Application.Command.User;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.User.Response;
using WeatherAttack.Hub.Events.Challenge;
using WeatherAttack.Hub.Services;

namespace WeatherAttack.Hub.Hubs.Challenge
{
    public class Challenge : HubBase
    {
        private IActionHandler<GetUserCommand> GetUserActionHandler { get; }

        private IActionHandler<GetCharacterCommand> GetCharacterActionHandler { get; }

        private static ConnectionInMemoryDatabase _connections { get; } = new ConnectionInMemoryDatabase();

        [HubMethodName(ChallengeEvents.GET_ONLINE_USERS)]
        public async Task GetOnlineUsersAsync(UserResponseDto user)
            => await Clients.Caller.SendAsync(ChallengeEvents.GET_ONLINE_USERS, _connections.Get());    

        [HubMethodName(ChallengeEvents.USER_JOINED_CHANNEL)]
        public async Task JoinChannelAsync(UserResponseDto user)
            => await Clients.Others.SendAsync(ChallengeEvents.USER_JOINED_CHANNEL, user);

        [HubMethodName(ChallengeEvents.USER_LEFT_CHANNEL)]
        public async Task QuitChannelAsync(UserResponseDto user)
            => await Clients.All.SendAsync(ChallengeEvents.USER_LEFT_CHANNEL, user);

        public override async Task OnConnectedAsync()
        {
            var user = GetUser();

            _connections.Add(user, Context.ConnectionId);

            var connectionId = _connections.Get(user);

            await GetOnlineUsersAsync(user);

            await JoinChannelAsync(user);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var user = GetUser();

            _connections.Remove(user);

            await QuitChannelAsync(user);
        }

        public Challenge(IActionHandler<GetUserCommand> getUserActionHandler, IActionHandler<GetCharacterCommand> getCharacterActionHandler) : base(getUserActionHandler)
        {
            GetUserActionHandler = getUserActionHandler;
            GetCharacterActionHandler = getCharacterActionHandler;
        }
    }
}
