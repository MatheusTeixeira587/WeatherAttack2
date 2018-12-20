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

        private IMapper<Entity.User, UserResponseDto, UserRequestDto> Mapper { get; }

        private IPasswordService PasswordService { get; }

        public void HandleAction(AddUserCommand command)
        {
            var user = Mapper.ToEntity(command.User);

            EntityValidator.Validate(user);

            if (user.isValid)
            {
                user.SetPassword(PasswordService.HashPassword(user.Password));
                Context.Add(user);
            }

            command.AddNotification(user.Notifications);
        }
    }
}
