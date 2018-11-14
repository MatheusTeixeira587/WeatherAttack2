using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using weatherattack2.src.Domain.Entities;
using weatherattack2.src.Domain.EntityValidator.Rules.User;
using weatherattack2.src.Domain.Notifications.User;

namespace weatherattack2.src.Domain.Validator
{
    public static class EntityValidator
    {
        public static void Validate(User user)
        {
            if (user.Name == null || user.Name.Trim().Length < UserRules.NameRules.MIN_LENGHT || user.Name.Trim().Length > UserRules.NameRules.MAX_LENGHT)
                user.AddNotification(UserNotifications.InvalidName);

            if (user.Email == null || user.Email.Trim().Length < UserRules.NameRules.MIN_LENGHT || user.Email.Trim().Length > UserRules.EmailRules.MAX_LENGTH)
                user.AddNotification(UserNotifications.InvalidEmail);

            if (user.Username == null || user.Username.Trim().Length < UserRules.UsernameRules.MIN_LENGTH || user.Username.Trim().Length > UserRules.UsernameRules.MAX_LENGTH)
                user.AddNotification(UserNotifications.InvalidUsername);

        }
    }
}