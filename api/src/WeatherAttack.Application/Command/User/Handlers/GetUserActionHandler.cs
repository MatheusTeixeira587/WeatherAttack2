using System.Linq;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.User.Request;
using WeatherAttack.Contracts.Dtos.User.Response;
using WeatherAttack.Contracts.Mapper;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Notifications;
using Entities = WeatherAttack.Domain.Entities;

namespace WeatherAttack.Application.Command.User.Handlers
{
    public class GetUserActionHandler : IActionHandler<GetUserCommand>
    {
        private IUserRepository Context { get; }

        private IMapper<Entities.User, UserRequestDto, UserResponseDto> Mapper { get; }

        public GetUserActionHandler(IUserRepository context, IMapper<Entities.User, UserRequestDto, UserResponseDto> mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public GetUserCommand ExecuteAction(GetUserCommand command)
        {
            var result = Context.FindBy(u => u.Id == command.Id).FirstOrDefault();

            if (result == null)
                command.AddNotification(WeatherAttackNotifications.User.UserNotFound);

            command.Result = result == null ? null : Mapper.ToDto(result);

            return command;
        }

    }
}
