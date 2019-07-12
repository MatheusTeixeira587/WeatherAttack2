using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using WeatherAttack.Application.Command.Character;
using WeatherAttack.Application.Command.User;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.User.Response;
using WeatherAttack.Hub.Commands.Challenge;
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

        [HubMethodName(ChallengeEvents.CHALLENGE_USER)]
        public async Task SendChallenge(SendChallengeCommand command)
        {
            var by = _connections.Get(command.By);
            var to = _connections.Get(command.To);

            await Clients.Client(to).SendAsync(ChallengeEvents.CHALLENGE_USER, command);
        }

        [HubMethodName(ChallengeEvents.REFUSE_CHALLENGE)]
        public async Task RefuseChallenge(SendChallengeCommand command)
        {
            var by = _connections.Get(command.By);
            var to = _connections.Get(command.To);
            command.Accepted = false;

            await Clients.Client(by).SendAsync(ChallengeEvents.REFUSE_CHALLENGE, command);
        }

        [HubMethodName(ChallengeEvents.ACCEPT_CHALLENGE)]
        public async Task AcceptChallenge(SendChallengeCommand command)
        {
            var by = _connections.Get(command.By);
            var to = _connections.Get(command.To);
            command.Accepted = true;

            await Clients.Client(by).SendAsync(ChallengeEvents.REFUSE_CHALLENGE, command);
        }

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
