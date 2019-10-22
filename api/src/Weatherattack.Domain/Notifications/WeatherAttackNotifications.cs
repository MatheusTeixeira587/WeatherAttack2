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
            public const string UsernameAlreadyInUse = "USN-007";
            public const string EmailAlreadyInUse = "USN-008";
            public const string EmailCannotBeChanged = "USN-009";
            public const string UsernameCannotBeChanged = "USN-010";

            public static readonly IReadOnlyList<Notification> Messages = new Notification[]
            {
                new Notification(InvalidEmail, "Invalid email.", "Email inválido.") ,
                new Notification(InvalidUsername, "Invalid Username.", "Username inválido."),
                new Notification(EmailIsRequired, "Email is required.", "Email é obrigatório."),
                new Notification(UsernameIsRequired, "Username is required.", "Nome de usuário é obrigatório."),
                new Notification(PasswordIsRequired, "Password is required.", "Senha é obrigatória."),
                new Notification(UserNotFound, "User not found.", "Usuario não encontrado."),
                new Notification(UsernameAlreadyInUse, "This username was already being taken.", "Nome já está em uso."),
                new Notification(EmailAlreadyInUse, "Email already in use.", "Email já está em uso."),
                new Notification(EmailCannotBeChanged, "Email adress cannot be changed.", "Endereço de email não pode ser alterado"),
                new Notification(UsernameCannotBeChanged, "Username cannot be changed.", "Nome de usuário não pode ser alterado")
            };
        }

        public static class Character
        {
            public const string InvalidCharacter = "CRN-001";

            public static readonly IReadOnlyList<Notification> Messages = new Notification[]
            {
                new Notification(InvalidCharacter, "Invalid character.", "Personagem inválido."),
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

            public static readonly IReadOnlyList<Notification> Messages = new Notification[]
            {
                new Notification(BaseDamageShouldBeHigherThan, $"Base Damage must be higher than {Rules.Spell.BaseDamage.MinDamage}.", $"O Dano base deve ser maior que {Rules.Spell.BaseDamage.MinDamage}."),
                new Notification(BaseDamageShouldBeLowerThan, $"Base Damage must be lower than {Rules.Spell.BaseDamage.MaxDamage}.", $"O Dano base deve ser menor que {Rules.Spell.BaseDamage.MaxDamage}."),
                new Notification(BaseManaCostShouldBeHigherThan, $"Base Mana Cost must be higher than {Rules.Spell.BaseManaCost.MinCost}.", $"O Custo de mana base deve ser maior que {Rules.Spell.BaseManaCost.MinCost}."),
                new Notification(BaseManaCostShouldBeLowerThan, $"Base Mana Cost must be lower than {Rules.Spell.BaseManaCost.MaxCost}.", $"O Custo de mana base deve ser menor que {Rules.Spell.BaseManaCost.MaxCost}."),
                new Notification(InvalidName, "Invalid name", "Nome inválido."),
                new Notification(NameIsRequired, "Name is required", "Nome é obrigatório."),
                new Notification(NotFound, "Spell not found.", "Magia não encontrada."),
            };

        }

        public static class Command
        {
            public const string InvalidId = "COM-001";
            public const string UserIsRequired = "COM-002";
            public const string InvalidValue = "COM-003";
            public const string InvalidCredentials = "COM-004";

            public static readonly IReadOnlyList<Notification> Messages = new Notification[]
            {
                new Notification(InvalidId, "Invalid Id.", "Id inválido."),
                new Notification(UserIsRequired, "User is required.", "Usuário é obrigatório."),
                new Notification(InvalidValue, "One or more values are invalid.", "Todos os campos devem ser preenchidos corretamente."),
                new Notification(InvalidCredentials, "Invalid credentials.", "Credenciais inválidas."),
            };
        }

        public static Notification Get(string cod)
            => List.FirstOrDefault(c => c.Code == cod);

        public static List<Notification> Get(ImmutableArray<string> codArray)
            => List.FindAll(c => codArray.Contains(c.Code));


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
