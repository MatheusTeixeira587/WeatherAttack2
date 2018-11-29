using Valit;
using Weatherattack.Domain.Entities;
using weatherattack2.src.Domain.Entities;
using weatherattack2.src.Domain.EntityValidation.Rules.User;
using weatherattack2.src.Domain.Notifications.User;

namespace weatherattack2.src.Domain.EntityValidation
{
    public static class EntityValidator
    {
       
        public static void Validate(User user)
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
                .Ensure(u => u.Name, _ => _
                    .Required()
                        .WithMessage(UserNotifications.NameIsRequired)
                    .Satisfies(u => u.Trim().Length > UserRules.NameRules.MinLength)
                        .WithMessage(UserNotifications.InvalidName)
                    .MaxLength(UserRules.NameRules.MaxLength)
                        .WithMessage(UserNotifications.InvalidName))
                 .Ensure(u => u.Username, _ => _
                    .Required()
                        .WithMessage(UserNotifications.UsernameIsRequired)
                    .Satisfies(u => u.Trim().Length > UserRules.UsernameRules.MinLength)
                        .WithMessage(UserNotifications.InvalidUsername)
                    .MaxLength(UserRules.UsernameRules.MaxLength)
                        .WithMessage(UserNotifications.InvalidUsername))
                .For(user)
                .Validate();

            foreach (var m in result.ErrorMessages)
            {
                user.AddNotification(UserNotifications.GetNotification(m));
            }

        }

        public static void Validate(Character character)
        {
            return;
        }

        public static void Validate(EntityBase entity)
        {
            return;
        }
    }
}