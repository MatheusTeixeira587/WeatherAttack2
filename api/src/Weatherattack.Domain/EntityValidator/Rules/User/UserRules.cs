using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace weatherattack2.src.Domain.EntityValidator.Rules.User
{
    public static class UserRules
    {       
        public static class NameRules
        {
            public static readonly int MinLength = 1;
            public static readonly int MaxLength = 60;
        }

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