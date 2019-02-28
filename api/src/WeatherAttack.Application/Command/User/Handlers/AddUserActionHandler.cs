using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.User.Request;
using WeatherAttack.Contracts.Dtos.User.Response;
using WeatherAttack.Contracts.interfaces;
using WeatherAttack.Contracts.Mapper;
using WeatherAttack.Domain.Contracts;
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

            if(user.IsNew)
                user.SetPassword(PasswordService.HashPassword(user.Password));

            if (user.IsValid)
            {
                if (user.IsNew)
                    Context.Add(user);
                else
                    Context.Edit(user);

                Context.Save();
            }

            command.AddNotification(user.Notifications);

            return command;
        }
    }
}
