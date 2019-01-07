using System.Collections.Generic;
using System.Linq;

namespace WeatherAttack.Domain.Notifications
{
    public static class UserNotifications
    {
        public static readonly string InvalidEmail = "UN-001";
        public static readonly string InvalidUsername = "UN-002";
        public static readonly string EmailIsRequired = "UN-003";
        public static readonly string UsernameIsRequired = "UN-004";
        public static readonly string PasswordIsRequired = "UN-005";
        public static readonly string UserNotFound = "UN-006";

        private static readonly IReadOnlyList<Notification> _messages = new List<Notification>
        {
            new Notification(InvalidEmail, "Invalid email.") ,
            new Notification(InvalidUsername, "Invalid Username."),
            new Notification(EmailIsRequired, "Email is required."),
            new Notification(UsernameIsRequired, "Username is required."),
            new Notification(PasswordIsRequired, "Password is required."),
            new Notification(UserNotFound, "Couldn't found any user with specified Id.")
        };

        public static Notification GetNotification(string cod)
        {
            return _messages.Select(m => m).Where(m => m.Code == cod).FirstOrDefault();
        }
    }    
}
