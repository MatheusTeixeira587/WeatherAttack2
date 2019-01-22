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

        public static class User
        {
            public static class Email
            {
                public static readonly int MinLength = 1;
                public static readonly int MaxLength = 100;
            }

            public static class Username
            {
                public static readonly int MinLength = 1;
                public static readonly int MaxLength = 20;
            }

        }

        public static class Command
        {
            public static class GetUser
            {
                public static readonly long MinValue = 1;
            }
        }
    }
}
