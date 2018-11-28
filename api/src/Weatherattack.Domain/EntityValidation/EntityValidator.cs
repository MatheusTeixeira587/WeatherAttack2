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
                        .WithMessage("UN-004")
                    .Satisfies(u => u.Trim().Length > 0)
                        .WithMessage("UN-002")
                    .Email()
                        .WithMessage("UN-002")
                    .MaxLength(UserRules.EmailRules.MaxLength)
                        .WithMessage("UN-002"))
                .Ensure(u => u.Name, _ => _
                    .Required()
                        .WithMessage("UN-005")
                    .Satisfies(u => u.Trim().Length > 0)
                        .WithMessage("UN-001")
                    .MaxLength(UserRules.NameRules.MaxLength)
                        .WithMessage("UN-001"))
                 .Ensure(u => u.Username, _ => _
                    .Required()
                        .WithMessage("UN-006")
                    .Satisfies(u => u.Trim().Length > 0)
                        .WithMessage("UN-003")
                    .MaxLength(UserRules.UsernameRules.MaxLength)
                        .WithMessage("UN-003"))
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