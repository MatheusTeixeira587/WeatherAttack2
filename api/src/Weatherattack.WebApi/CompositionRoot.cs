using LightInject;
using WeatherAttack.Application.Contracts.Dtos.User.Request;
using WeatherAttack.Application.Contracts.Dtos.User.Response;
using WeatherAttack.Application.Contracts.interfaces;
using WeatherAttack.Application.Contracts.Command;
using WeatherAttack.Application.Mapper;
using WeatherAttack.Application.Mapper.User;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Entities;
using WeatherAttack.Infra.Repositories;
using WeatherAttack.Security.Services;
using WeatherAttack.Application.Command.User;
using WeatherAttack.Application.Command.User.Handlers;

namespace WeatherAttack.WebApi
{
    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IPasswordService, PasswordService>();

            serviceRegistry.Register<IUserRepository, UserRepository>();

            serviceRegistry.Register<IMapper<User, UserRequestDto, UserResponseDto>, UserEntityMapper>();

            serviceRegistry.Register<IActionHandler<AddUserCommand>, AddUserActionHandler>();

            serviceRegistry.Register<IActionHandler<GetAllUsersCommand>, GetAllUsersActionHandler>();
        }
    }
}
