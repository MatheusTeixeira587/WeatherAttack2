using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            if (user.Name == null || user.Name.Trim().Length < UserRules.NameRules.MinLength || user.Name.Trim().Length > UserRules.NameRules.MaxLength)
                user.AddNotification(UserNotifications.InvalidName);

            if (user.Email == null || user.Email.Trim().Length < UserRules.NameRules.MinLength || user.Email.Trim().Length > UserRules.EmailRules.MaxLength)
                user.AddNotification(UserNotifications.InvalidEmail);

            if (user.Username == null || user.Username.Trim().Length < UserRules.UsernameRules.MinLength || user.Username.Trim().Length > UserRules.UsernameRules.MaxLength)
                user.AddNotification(UserNotifications.InvalidUsername);

        }

        public static void a()
        {
            var result = ValitRules<User>
                .Create()
                .Ensure(u => u.Email, _ => _
                    .Required()
                    .Email()
                    .MaxLength(UserRules.EmailRules.MaxLength));
                    
        }
    }
}