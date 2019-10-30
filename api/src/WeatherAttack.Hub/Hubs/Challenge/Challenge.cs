using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using WeatherAttack.Application.Command.User;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.User.Response;
using WeatherAttack.Contracts.Interfaces;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Hub.Commands.Challenge;
using WeatherAttack.Hub.Events.Challenge;

namespace WeatherAttack.Hub.Hubs.Challenge
{
    public sealed class Challenge : HubBase
    {
        private IConnectionRepository<UserResponseDto> ConnectionRepository { get; }

        [HubMethodName(ChallengeEvents.GET_ONLINE_USERS)]
        public async Task GetOnlineUsersAsync(UserResponseDto user)
            => await Clients.Caller.SendAsync(ChallengeEvents.GET_ONLINE_USERS, ConnectionRepository.Get());

        [HubMethodName(ChallengeEvents.USER_JOINED_CHANNEL)]
        public async Task JoinChannelAsync(UserResponseDto user)
            => await Clients.Others.SendAsync(ChallengeEvents.USER_JOINED_CHANNEL, user);

        [HubMethodName(ChallengeEvents.USER_LEFT_CHANNEL)]
        public async Task QuitChannelAsync(UserResponseDto user)
        {
            ConnectionRepository.Remove(user);
            await Clients.All.SendAsync(ChallengeEvents.USER_LEFT_CHANNEL, user);
        }

        [HubMethodName(ChallengeEvents.CHALLENGE_USER)]
        public async Task SendChallengeAsync(SendChallengeCommand command)
        {
            var to = ConnectionRepository.GetConnection(command.To);

            command.By = ConnectionRepository.Find(command.By);
            command.To = ConnectionRepository.Find(command.To);

            await Clients.Client(to).SendAsync(ChallengeEvents.CHALLENGE_USER, command);
        }

        [HubMethodName(ChallengeEvents.REFUSE_CHALLENGE)]
        public async Task RefuseChallengeAsync(SendChallengeCommand command)
        {
            var by = ConnectionRepository.GetConnection(command.By);
            command.Accepted = false;

            await Clients.Client(by).SendAsync(ChallengeEvents.REFUSE_CHALLENGE, command);
        }

        [HubMethodName(ChallengeEvents.ACCEPT_CHALLENGE)]
        public async Task AcceptChallengeAsync(SendChallengeCommand command)
        {
            var by = ConnectionRepository.GetConnection(command.By);
            command.Accepted = true;

            await Clients.Client(by).SendAsync(ChallengeEvents.ACCEPT_CHALLENGE, command);
        }

        public override async Task OnConnectedAsync()
        {
            var user = await GetUser();

            ConnectionRepository.Add(user, Context.ConnectionId);

            await GetOnlineUsersAsync(user);

            await JoinChannelAsync(user);

            await base.OnConnectedAsync();
        }


        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var user = await GetUser();

            ConnectionRepository.Remove(user);

            await QuitChannelAsync(user);

            await base.OnDisconnectedAsync(exception);
        }

        public Challenge(IUserRepository userRepository, IConnectionRepository<UserResponseDto> connectionRepository) : base(userRepository)
        {
            ConnectionRepository = connectionRepository;
        }
    }
}
