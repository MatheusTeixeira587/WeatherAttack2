using System.Linq;
using System.Threading.Tasks;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.User.Request;
using WeatherAttack.Contracts.Dtos.User.Response;
using WeatherAttack.Contracts.Mapper;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Notifications;
using Entities = WeatherAttack.Domain.Entities;

namespace WeatherAttack.Application.Command.User.Handlers
{
    public class GetUserActionHandler : IActionHandlerAsync<GetUserCommand>
    {
        private IUserRepository Context { get; }

        private IMapper<Entities.User, UserRequestDto, UserResponseDto> Mapper { get; }

        public GetUserActionHandler(IUserRepository context, IMapper<Entities.User, UserRequestDto, UserResponseDto> mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public async Task<GetUserCommand> ExecuteActionAsync(GetUserCommand command)
        {
            var result = await Context
                .Find(command.Id);

            if (result is null)
                command.AddNotification(WeatherAttackNotifications.User.UserNotFound);
            else
                command.Result = Mapper.ToDto(result);

            return command;
        }
    }
}
