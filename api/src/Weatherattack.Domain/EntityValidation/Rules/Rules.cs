using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAttack.Domain.EntityValidation.Rules
{
    public static class Rules
    {
        public static class Character
        {
            public static class HealthPoints
            {
                public const long InitialValue = 100;
            }

            public static class ManaPoints
            {
                public const long InitialValue = 100;
            }

            public static class Battles
            {
                public const long InitialValue = 0;
            }

            public static class Wins
            {
                public const long InitialValue = 0;
            }

            public static class Losses
            {
                public const long InitialValue = 0;
            }

            public static class Medals
            {
                public const long InitialValue = 0;
                public const long OnWinIncreaseValue = 10;
                public const long OnLossIncreaseValue = (OnWinIncreaseValue / 2);
            }
        }

        public static class User
        {
            public static class Email
            {
                public const int MinLength = 1;
                public const int MaxLength = 100;
            }

            public static class Username
            {
                public const int MinLength = 1;
                public const int MaxLength = 20;
            }

            public static class PermissionLevel
            {
                public const byte User = 0;
                public const byte Admin = 1;
            }

        }

        public static class Command
        {
            public static class GetUser
            {
                public const long MinValue = 1;
            }
        }

        public static class Spell
        {
            public static class Name
            {
                public const int MinLenght = 1;
                public const int MaxLenght = 20;
            }

            public static class BaseDamage
            {
                public const int MinDamage = 1;
                public const int MaxDamage = 50;
            }

            public static class BaseManaCost
            {
                public const int MinCost = 10;
                public const int MaxCost = 100;
            }
        }
    }
}
