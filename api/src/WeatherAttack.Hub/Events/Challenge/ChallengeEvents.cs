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
        public const string GET_ONLINE_USERS = "GET_ONLINE_USERS";
        public const string CHALLENGE_USER = "CHALLENGE_USER";
        public const string ACCEPT_CHALLENGE = "ACCEPT_CHALLENGE";
        public const string REFUSE_CHALLENGE = "REFUSE_CHALLENGE";
    }
}
