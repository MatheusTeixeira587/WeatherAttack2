using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using WeatherAttack.Domain.EntityValidation.Rules;

namespace WeatherAttack.Domain.Notifications
{
    public static class WeatherAttackNotifications
    {
        private static List<Notification> List  => GetFullNotificationList();

        public static class User
        {
            public const string InvalidEmail = "USN-001";
            public const string InvalidUsername = "USN-002";
            public const string EmailIsRequired = "USN-003";
            public const string UsernameIsRequired = "USN-004";
            public const string PasswordIsRequired = "USN-005";
            public const string UserNotFound = "USN-006";

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
            public const string InvalidCharacter = "CRN-001";

            public static readonly IReadOnlyList<Notification> Messages = new List<Notification>
            {
                new Notification(InvalidCharacter, "Invalid character."),
            };
        }

        public static class Spell
        {
            public const string MustBePositive = "SPL-001";
            public const string ShouldBeHigherThan = "SPL-002";
            public const string ShouldBeLowerThan = "SPL-003";


            public static readonly IReadOnlyList<Notification> Messages = new List<Notification>
            {
                new Notification(MustBePositive, "Base Damage must be a positive integer."),
                new Notification(ShouldBeHigherThan, $"Base Damage must be higher than {Rules.Spell.BaseDamage.MinDamage}."),
                new Notification(ShouldBeLowerThan, $"Base Damage must be lower than {Rules.Spell.BaseDamage.MaxDamage}."),
            };
        }

        public static class Command
        {
            public const string InvalidId = "COM-001";
            public const string UserIsRequired = "COM-002";

            public static readonly IReadOnlyList<Notification> Messages = new List<Notification>
            {
                new Notification(InvalidId, "Invalid Id."),
                new Notification(UserIsRequired, "User is required."),
            };
        }

        public static Notification Get(string cod)
        {            
            return List.Where(m => m.Code == cod).Select(m => m).First();
        }

        public static List<Notification> Get(ImmutableArray<string> codArray)
        {
            return List.Where(m => codArray.Contains(m.Code)).Select(m => m).ToList();
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
