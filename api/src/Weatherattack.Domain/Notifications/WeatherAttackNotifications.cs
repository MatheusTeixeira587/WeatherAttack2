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
                new Notification(UserNotFound, "Couldn't find any User with specified Id.")
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
            public const string BaseDamageShouldBeHigherThan = "SPL-001";
            public const string BaseDamageShouldBeLowerThan = "SPL-002";
            public const string BaseManaCostShouldBeHigherThan = "SPL-003";
            public const string BaseManaCostShouldBeLowerThan = "SPL-004";
            public const string InvalidName = "SPL-005";
            public const string NameIsRequired = "SPL-006";
            public const string NotFound = "SPL-007";

            public static readonly IReadOnlyList<Notification> Messages = new List<Notification>
            {
                new Notification(BaseDamageShouldBeHigherThan, $"Base Damage must be higher than {Rules.Spell.BaseDamage.MinDamage}."),
                new Notification(BaseDamageShouldBeLowerThan, $"Base Damage must be lower than {Rules.Spell.BaseDamage.MaxDamage}."),
                new Notification(BaseManaCostShouldBeHigherThan, $"Base Mana Cost must be higher than {Rules.Spell.BaseManaCost.MinCost}"),
                new Notification(BaseManaCostShouldBeLowerThan, $"Base Mana Cost must be lower than {Rules.Spell.BaseManaCost.MaxCost}"),
                new Notification(InvalidName, "Invalid name"),
                new Notification(NameIsRequired, "Name is required"),
                new Notification(NotFound, "Couldn't find any Spell with specified Id.")
            };
        }

        public static class Command
        {
            public const string InvalidId = "COM-001";
            public const string UserIsRequired = "COM-002";
            public const string InvalidValue = "COM-003";

            public static readonly IReadOnlyList<Notification> Messages = new List<Notification>
            {
                new Notification(InvalidId, "Invalid Id."),
                new Notification(UserIsRequired, "User is required."),
                new Notification(InvalidValue, "One or more values are invalid."),
            };
        }

        public static Notification Get(string cod)
        {            
            return List.FirstOrDefault(c => c.Code == cod);
        }

        public static List<Notification> Get(ImmutableArray<string> codArray)
        {
            return List.FindAll(c => codArray.Contains(c.Code));
        }


        private static List<Notification> GetFullNotificationList()
        {
            var list = new List<Notification>();

            list.AddRange(User.Messages);
            list.AddRange(Command.Messages);
            list.AddRange(Character.Messages);
            list.AddRange(Spell.Messages);

            return list;
        }
    }    
}
