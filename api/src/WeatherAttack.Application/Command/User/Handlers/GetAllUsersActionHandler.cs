using System.Linq;
using WeatherAttack.Application.Contracts.Command;
using WeatherAttack.Application.Contracts.Dtos.User.Request;
using WeatherAttack.Application.Contracts.Dtos.User.Response;
using WeatherAttack.Application.Mapper;
using WeatherAttack.Domain.Contracts;
using Entities = WeatherAttack.Domain.Entities;

namespace WeatherAttack.Application.Command.User.Handlers
{
    public class GetAllUsersActionHandler : IActionHandler<GetAllUsersCommand>
    {
        private IUserRepository Context { get; }

        private IMapper<Entities.User, UserRequestDto, UserResponseDto> Mapper { get; }

        public GetAllUsersActionHandler(IUserRepository context, IMapper<Entities.User, UserRequestDto, UserResponseDto> mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public GetAllUsersCommand ExecuteAction(GetAllUsersCommand command)
        {
            var users = Context.GetAll()?
                .ToList()
                .Select(f => Mapper.ToDto(f));

            if (users != null || users.Count() != 0)
                command.Result = users;

            return command;
        }
    }
}
