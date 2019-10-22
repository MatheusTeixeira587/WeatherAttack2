using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WeatherAttack.Domain.Contracts
{
    public interface IRepository<Entity> where Entity : class
    {
        Task<IList<Entity>> GetAsync();

        Task<IList<Entity>> GetAsync(int skip, int take);

        Task<IList<Entity>> GetAsync(Expression<Func<Entity, bool>> predicate);

        Task<IList<Entity>> GetAsync(int skip, int take, Expression<Func<Entity, bool>> predicate);
        Task<Entity> FindAsync(Expression<Func<Entity, bool>> predicate);

        Task<Entity> FindAsync(long primaryKey);

        Task<long> CountAsync();

        Task<Entity> AddAsync(Entity entity);

        Entity Delete(Entity entity);

        Entity Edit(Entity entity);

        void SaveAsync();
    }
}
