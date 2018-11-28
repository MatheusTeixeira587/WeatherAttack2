using System.Collections.Generic;
using System.Linq;
using Valit;
using weatherattack2.src.Domain.Entities;

namespace weatherattack2.src.Domain.Notifications.User
{
    public static class UserNotifications
    {

        private static readonly IReadOnlyList<Notification> _messages = new List<Notification>
        {
            new Notification("UN-001", "Invalid name") ,
            new Notification("UN-002", "Invalid email") ,
            new Notification("UN-003", "Invalid Username"),
            new Notification("UN-004", "Email is required"),
            new Notification("UN-005", "Name is required"),
            new Notification("UN-006", "Username is required"),
        };

        public static Notification GetNotification(string cod)
        {
            return _messages.Select(m => m).Where(m => m.Code == cod).FirstOrDefault();
        }
    }    
}
