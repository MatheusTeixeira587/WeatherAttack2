using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace WeatherAttack.Domain.Notifications
{
    public static class WeatherAttackNotifications
    {
        private static List<Notification> List  => GetFullNotificationList();

        public static class User
        {
            public static readonly string InvalidEmail = "USN-001";
            public static readonly string InvalidUsername = "USN-002";
            public static readonly string EmailIsRequired = "USN-003";
            public static readonly string UsernameIsRequired = "USN-004";
            public static readonly string PasswordIsRequired = "USN-005";
            public static readonly string UserNotFound = "USN-006";

            public static readonly IReadOnlyList<Notification> Messages = new List<Notification>
            {
                new Notification(InvalidEmail, "Invalid email.") ,
                new Notification(InvalidUsername, "Invalid Username."),
                new Notification(EmailIsRequired, "Email is required."),
                new Notification(UsernameIsRequired, "Username is required."),
                new Notification(PasswordIsRequired, "Password is required."),
                new Notification(UserNotFound, "Couldn't found any user with specified Id.")
            };
        }

        public static class Character
        {
            public static readonly string InvalidCharacter = "CRN-001";

            public static readonly IReadOnlyList<Notification> Messages = new List<Notification>
            {
                new Notification(InvalidCharacter, "Invalid character."),
            };
        }

        public static class Command
        {
            public static readonly string InvalidId = "COM-001";
            public static readonly string UserIsRequired = "COM-002";

            public static readonly IReadOnlyList<Notification> Messages = new List<Notification>
            {
                new Notification(InvalidId, "Invalid Id."),
                new Notification(UserIsRequired, "User is required."),
            };
        }

        public static Notification GetNotification(string cod)
        {            
            return List.Select(m => m).Where(m => m.Code == cod).First();
        }

        public static List<Notification> GetNotification(ImmutableArray<string> codArray)
        {
            return List.Select(m => m).Where(m => codArray.Contains(m.Code)).ToList();
        }


        private static List<Notification> GetFullNotificationList()
        {
            var list = new List<Notification>();

            list.AddRange(User.Messages);
            list.AddRange(Command.Messages);
            list.AddRange(Character.Messages);

            return list;
        }
    }    
}
