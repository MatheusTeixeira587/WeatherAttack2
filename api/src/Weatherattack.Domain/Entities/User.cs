using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weatherattack.Domain.Entities;

namespace weatherattack2.src.Domain.Entities
{
    public class User : EntityBase
    {
        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Username { get; private set; }

        public Character Character { get; private set; }

        public User(string name, string email, string username)
        {
            Name = name;
            Email = email;
            Username = username;
            Character = new Character();
        }

    }
}