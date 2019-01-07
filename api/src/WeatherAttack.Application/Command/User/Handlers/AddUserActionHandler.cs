using WeatherAttack.Application.Contracts.Command;
using WeatherAttack.Application.Contracts.Dtos.User.Request;
using WeatherAttack.Application.Contracts.Dtos.User.Response;
using WeatherAttack.Application.Contracts.interfaces;
using WeatherAttack.Application.Mapper;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.EntityValidation;
using Entity = WeatherAttack.Domain.Entities;

namespace WeatherAttack.Application.Command.User.Handlers
{
    public class AddUserActionHandler : IActionHandler<AddUserCommand>
    {
        private IUserRepository Context { get; }

        private IMapper<Entity.User, UserRequestDto, UserResponseDto> Mapper { get; }

        private IPasswordService PasswordService { get; }

        public AddUserActionHandler(IUserRepository context, IMapper<Entity.User, UserRequestDto, UserResponseDto> mapper, IPasswordService passwordService)
        {
            Context = context;
            Mapper = mapper;
            PasswordService = passwordService;
        }

        public AddUserCommand ExecuteAction(AddUserCommand command)
        {
            var user = Mapper.ToEntity(command.User);

            if (user.IsValid())
            {
                if (user.IsNew)
                {
                    user.SetPassword(PasswordService.HashPassword(user.Password));
                    Context.Add(user);
                }
                else
                {
                    Context.Edit(user);
                }
            }

            command.AddNotification(user.Notifications);

            return command;
        }
    }
}
