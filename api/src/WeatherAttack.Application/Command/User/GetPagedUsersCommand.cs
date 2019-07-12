using System.Collections.Generic;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.User.Response;

namespace WeatherAttack.Application.Command.User
{
    public class GetPagedUsersCommand : PagedCommand
    {
        public ICollection<UserResponseDto> Result { get; set; }
    }
}
