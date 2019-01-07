using System.Linq;
using WeatherAttack.Application.Contracts.Command;
using WeatherAttack.Application.Contracts.Dtos.User.Request;
using WeatherAttack.Application.Contracts.Dtos.User.Response;
using WeatherAttack.Application.Mapper;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Notifications;
using Entities = WeatherAttack.Domain.Entities;

namespace WeatherAttack.Application.Command.User.Handlers
{
    public class GetUserActionHandler : IActionHandler<GetUserCommand>
    {
        private IUserRepository Context { get; }

        private IMapper<Entities.User, UserRequestDto, UserResponseDto> Mapper { get; }

        public GetUserActionHandler(IUserRepository context)
        {
            Context = context;
        }

        public GetUserCommand ExecuteAction(GetUserCommand command)
        {
            var result = Context.FindBy(u => u.Id == command.Id)
                .Select(u => Mapper.ToDto(u))
                .FirstOrDefault();

            if (result == null)
            {
                command.AddNotification(UserNotifications.GetNotification(UserNotifications.UserNotFound));
            }

            command.Result = result;

            return command;
        }

    }
}
