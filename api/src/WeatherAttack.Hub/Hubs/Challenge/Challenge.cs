using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using WeatherAttack.Contracts.Dtos.User.Response;
using WeatherAttack.Hub.Events.Challenge;
using SignalRHub = Microsoft.AspNetCore.SignalR.Hub;

namespace WeatherAttack.Hub.Hubs.Challenge
{
    public class Challenge : SignalRHub
    {
        public async Task JoinChannel(UserResponseDto user)
            => await Clients.All.SendAsync(ChallengeEvents.UserJoinedChannel, user);

        public async Task QuitChannel(UserResponseDto user)
            => await Clients.All.SendAsync(ChallengeEvents.UserLeftChannel, user);

        public override async Task OnConnectedAsync()
        {
            var user = this.Context.User;

            await Clients.User(this.Context.UserIdentifier).SendAsync("Seja Welcomido");
        }
    }
}
