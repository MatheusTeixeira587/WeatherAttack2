using Weatherattack.Domain.Entities;
using weatherattack2.src.Domain.EntityValidation;

namespace weatherattack2.src.Domain.Entities
{
    public class User : EntityBase
    {
        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Username { get; private set; }

        public Character Character { get; private set; } = new Character();

        public User(string name, string email, string username)
        {
            Name = name;
            Email = email;
            Username = username;
        }

        public new void Validate()
        {
            EntityValidator.Validate(this);
        }

    }
}