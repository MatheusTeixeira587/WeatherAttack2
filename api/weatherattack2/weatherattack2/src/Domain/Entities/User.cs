using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace weatherattack2.src.Domain.Entities
{
    public class User : EntityBase
    {
        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Username { get; private set; }

    }
}