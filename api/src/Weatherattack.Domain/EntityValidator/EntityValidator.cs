using Valit;
using weatherattack2.src.Domain.Entities;
using weatherattack2.src.Domain.EntityValidator.Rules.User;
using weatherattack2.src.Domain.Notifications.User;

namespace weatherattack2.src.Domain.Validator
{
    public static class EntityValidator
    {
       
        public static void Validate(User user)
        {
            var result = ValitRules<User>
                .Create()
                .Ensure(u => u.Email, _ => _
                    .Required()
                    .Satisfies(u => u.Trim().Length > 0)
                    .Email()
                    .MaxLength(UserRules.EmailRules.MaxLength)
                    .WithMessage("InvalidEmail"))
                .Ensure(u => u.Name, _ => _
                    .Required()
                    .Satisfies(u => u.Trim().Length > 0)
                    .MaxLength(UserRules.NameRules.MaxLength)
                    .WithMessage("InvalidName"))
                 .Ensure(u => u.Username, _ => _
                    .Required()
                    .Satisfies(u => u.Trim().Length > 0)
                    .MaxLength(UserRules.UsernameRules.MaxLength)
                    .WithMessage("InvalidUsername"))
                .Validate();

            foreach (var m in result.ErrorMessages)
            {
                user.AddNotification(UserNotifications.GetNotification(m));
            }
        }
    }
}