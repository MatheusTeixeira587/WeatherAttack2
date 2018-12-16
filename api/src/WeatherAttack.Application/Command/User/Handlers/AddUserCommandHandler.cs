using Weatherattack.Application.Command.User;
using Weatherattack.Application.Contracts.Dtos.User.Response;
using Weatherattack.Domain.EntityValidation;
using WeatherAttack.Application.Contracts.Dtos.User.Request;
using WeatherAttack.Application.Contracts.interfaces;
using WeatherAttack.Application.Mapper;
using WeatherAttack.Domain.Contracts;
using Entity = WeatherAttack.Domain.Entities;

namespace WeatherAttack.Application.Command.User.Handlers
{
    public class AddUserCommandHandler
    {
        private IUserRepository Context { get; }

        private IMapper<Entity.User, UserResponseDto, UserRequestDto> Mapper { get; }

        private IPasswordService PasswordService { get; }

        public AddUserCommand HandleAction(AddUserCommand command)
        {
            var user = Mapper.ToEntity(command.User);

            EntityValidator.Validate(user);

            if (user.isValid)
            {
                user.SetPassword(PasswordService.HashPassword(user.Password));
                Context.Add(user);
            }

            command.AddNotification(user.Notifications);

            return command;
        }
    }
}
