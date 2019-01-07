
using Valit;
using WeatherAttack.Domain.EntityValidation.Rules.User;
using WeatherAttack.Domain.Notifications;

namespace WeatherAttack.Domain.Entities
{
    public class User : EntityBase
    {
        public string Email { get; private set; }

        public string Username { get; private set; }

        public string Password { get; private set; }

        public Character Character { get; private set; } = new Character();

        public User(string email, string username)
        {
            Email = email;
            Username = username;
        }

        public void SetPassword(string password)
        {
            Password = password;
        }

        protected override void Validate()
        {
            var result = ValitRules<User>
                .Create()
                .Ensure(u => u.Email, _ => _
                    .Required()
                        .WithMessage(UserNotifications.EmailIsRequired)
                    .Satisfies(u => u.Trim().Length > UserRules.EmailRules.MinLength)
                        .WithMessage(UserNotifications.InvalidEmail)
                    .Email()
                        .WithMessage(UserNotifications.InvalidEmail)
                    .MaxLength(UserRules.EmailRules.MaxLength)
                        .WithMessage(UserNotifications.InvalidEmail))
                 .Ensure(u => u.Username, _ => _
                    .Required()
                        .WithMessage(UserNotifications.UsernameIsRequired)
                    .Satisfies(u => u.Trim().Length > UserRules.UsernameRules.MinLength)
                        .WithMessage(UserNotifications.InvalidUsername)
                    .MaxLength(UserRules.UsernameRules.MaxLength)
                        .WithMessage(UserNotifications.InvalidUsername))
                .Ensure(u => u.Password, _ => _
                    .Required()
                        .WithMessage(UserNotifications.PasswordIsRequired))
                .For(this)
                .Validate();

            foreach (var m in result.ErrorMessages)
            {
                AddNotification(UserNotifications.GetNotification(m));
            }
        }
    }
}