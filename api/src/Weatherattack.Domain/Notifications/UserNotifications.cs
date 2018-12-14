using System.Collections.Generic;
using System.Linq;

namespace Weatherattack.Domain.Notifications
{
    public static class UserNotifications
    {
        public static readonly string InvalidName = "UN-001";
        public static readonly string InvalidEmail = "UN-002";
        public static readonly string InvalidUsername = "UN-003";
        public static readonly string EmailIsRequired = "UN-004";
        public static readonly string NameIsRequired = "UN-005";
        public static readonly string UsernameIsRequired = "UN-006";
        public static readonly string PasswordIsRequired = "UN-007";


        private static readonly IReadOnlyList<Notification> _messages = new List<Notification>
        {
            new Notification("UN-001", "Invalid name") ,
            new Notification("UN-002", "Invalid email") ,
            new Notification("UN-003", "Invalid Username"),
            new Notification("UN-004", "Email is required"),
            new Notification("UN-005", "Name is required"),
            new Notification("UN-006", "Username is required"),
            new Notification("UN-007", "Password is required"),
        };

        public static Notification GetNotification(string cod)
        {
            return _messages.Select(m => m).Where(m => m.Code == cod).FirstOrDefault();
        }
    }    
}
