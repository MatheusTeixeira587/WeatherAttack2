using System.Collections.Generic;

namespace WeatherAttack.Contracts.Interfaces
{
    public interface IConnectionRepository<Entity>
    {
        int Count();

        void Add(Entity key, string value);

        void Remove(Entity key);

        string GetConnection(Entity key);

        ICollection<Entity> Get();

        Entity Find(Entity key);

        ICollection<Entity> Find(ICollection<Entity> key);
    }
}
