namespace WeatherAttack.Domain.EntityValidation.Rules.Character
{
    public static class CharacterRules
    {
        public static class HealthPoints
        {
            public static readonly long InitialValue = 100;
        }

        public static class ManaPoints
        {
            public static readonly long InitialValue = 100;
        }

        public static class Battles
        {
            public static readonly long InitialValue = 0;
        }

        public static class Wins
        {
            public static readonly long InitialValue = 0;
        }

        public static class Losses
        {
            public static readonly long InitialValue = 0;
        }

        public static class Medals
        {
            public static readonly long InitialValue = 0;
            public static readonly long OnWinIncreaseValue = 10;
            public static readonly long OnLossIncreaseValue = (OnWinIncreaseValue / 2);
        }
    }
}
