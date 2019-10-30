using System.Linq;
using System.Threading.Tasks;
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
    public sealed class AddUserActionHandler : IActionHandlerAsync<AddUserCommand>
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

        public async Task<AddUserCommand> ExecuteActionAsync(AddUserCommand command)
        {
            var user = Mapper.ToEntity(command.User);
           
            if (user.IsValid)
            {
                user.SetPassword(PasswordService.HashPassword(user.Password));

                if (user.IsNew)
                {
                    user = await EnsureUniquenessOfEmailAndUsernameOnAddAsync(user);

                    if (!user.HasNotification())
                    {
                        user.SetCharacter(new Entity.Character());
                        await Context.AddAsync(user);
                    }                  
                }
                else
                {
                    user = await EnsureUniquenessOfEmailAndUsernameOnEditAsync(user);

                    if (!user.HasNotification())
                    {
                        Context.Edit(user);
                    }
                }

                Context.SaveAsync();
            }

            command.AddNotification(user.Notifications);

            return command;
        }

        private async Task<Entity.User> EnsureUniquenessOfEmailAndUsernameOnAddAsync(Entity.User user)
        {
            var result = await Context
                .GetAsync(u => u.Username == user.Username || u.Email == user.Email);

            if (result != null)
            {
                if (result.Any(r => r.Email == user.Email))
                    user.AddNotification(WeatherAttackNotifications.User.EmailAlreadyInUse);

                if (result.Any(r => r.Username == user.Username))
                    user.AddNotification(WeatherAttackNotifications.User.UsernameAlreadyInUse);
            }

            return user;
        }

        private async Task<Entity.User> EnsureUniquenessOfEmailAndUsernameOnEditAsync(Entity.User user)
        {
            var result = await Context
                .FindAsync(user.Id);

            if (result != null)
            {
                if (result.Email != user.Email)
                    user.AddNotification(WeatherAttackNotifications.User.EmailCannotBeChanged);

                if (result.Username != user.Username)
                    user.AddNotification(WeatherAttackNotifications.User.UsernameCannotBeChanged);
            }

            return user;
        }
    }
}
