using System.Collections.Generic;
using WeatherAttack.Application.Contracts.Command;
using WeatherAttack.Application.Contracts.Dtos.User.Response;

namespace WeatherAttack.Application.Command.User
{
    public class GetAllUsersCommand : CommandBase
    {
        public ICollection<UserResponseDto> Result { get; set; }
    }
}
