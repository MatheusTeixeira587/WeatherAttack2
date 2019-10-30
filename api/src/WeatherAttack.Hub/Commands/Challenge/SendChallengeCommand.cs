using System;
using System.Collections.Generic;
using System.Text;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.User.Response;

namespace WeatherAttack.Hub.Commands.Challenge
{
    public sealed class SendChallengeCommand : CommandBase
    {
        public UserResponseDto By { get; set; }

        public UserResponseDto To { get; set; }

        public bool Accepted = false;

        public SendChallengeCommand(long id, UserResponseDto by, UserResponseDto to, bool accepted) : base(id) {
            By = by;
            To = to;
            Accepted = accepted;
        }
    }
}
