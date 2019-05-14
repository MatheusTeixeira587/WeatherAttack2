using System;
using System.Collections.Generic;
using System.Text;
using WeatherAttack.Contracts.Dtos.User.Response;

namespace WeatherAttack.Hub.Events.Challenge
{
    public static class ChallengeEvents
    {
        public static string UserJoinedChannel = "UserJoinedChannel";
        public static string UserLeftChannel = "UserLeftChannel";
    }
}
