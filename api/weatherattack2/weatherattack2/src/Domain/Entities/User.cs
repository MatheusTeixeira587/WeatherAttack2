using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace weatherattack2.src.Domain.Entities
{
    public class User
    {
        public long Id { get; private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

    }
}