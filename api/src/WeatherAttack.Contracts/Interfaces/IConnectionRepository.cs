using System.Collections.Generic;

namespace WeatherAttack.Contracts.Interfaces
{
    public interface IConnectionRepository<Entity>
    {
        void Add(Entity key, string value);

        void Remove(Entity key);

        string GetConnection(Entity key);

        ICollection<Entity> Get();

        Entity Find(Entity key);
    }
}
