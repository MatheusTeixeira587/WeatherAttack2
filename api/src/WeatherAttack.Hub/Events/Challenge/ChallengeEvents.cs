using System;
using System.Collections.Generic;
using System.Text;
using WeatherAttack.Contracts.Dtos.User.Response;

namespace WeatherAttack.Hub.Events.Challenge
{
    public static class ChallengeEvents
    {
        public const string USER_JOINED_CHANNEL = "USER_JOINED_CHANNEL";
        public const string USER_LEFT_CHANNEL = "USER_LEFT_CHANNEL";
    }
}
