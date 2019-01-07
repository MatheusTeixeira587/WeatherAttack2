namespace WeatherAttack.Domain.EntityValidation.Rules.User
{
    public static class UserRules
    {       
        public static class EmailRules
        {
            public static readonly int MinLength = 1;
            public static readonly int MaxLength = 100;
        }

        public static class UsernameRules
        {
            public static readonly int MinLength = 1;
            public static readonly int MaxLength = 20;
        }

    }

    
}