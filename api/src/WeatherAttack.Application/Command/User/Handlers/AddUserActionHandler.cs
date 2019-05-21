using System.Linq;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.User.Request;
using WeatherAttack.Contracts.Dtos.User.Response;
using WeatherAttack.Contracts.interfaces;
using WeatherAttack.Contracts.Mapper;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Notifications;
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

            user.SetPassword(PasswordService.HashPassword(user.Password));

            if (user.IsValid)
            {
                if (user.IsNew)
                {
                    EnsureUniquenessOfEmailAndUsername(user);

                    if (!user.HasNotification())
                    {
                        user.SetCharacter(new Entity.Character());
                        Context.Add(user);
                    }                  
                }
                else
                {
                    Context.Edit(user);
                }

                Context.Save();
            }

            command.AddNotification(user.Notifications);

            return command;
        }

        private void EnsureUniquenessOfEmailAndUsername(Entity.User user)
        {
            var result = Context.FindBy(u => u.Username == user.Username
                                                    || u.Email == user.Email)?.ToList();

            if (result != null)
            {
                if (result.Any(r => r.Email == user.Email))
                    user.AddNotification(WeatherAttackNotifications.User.EmailAlreadyInUse);

                if (result.Any(r => r.Username == user.Username))
                    user.AddNotification(WeatherAttackNotifications.User.UsernameAlreadyInUse);
            }
        }
    }
}
