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

        Task<IList<TResult>> GetAsync<TResult>(Expression<Func<Entity, TResult>> selector);

        Task<IList<TResult>> GetAsync<TResult>(Expression<Func<Entity, bool>> predicate, Expression<Func<Entity, TResult>> selector);

        Task<IList<TResult>> GetAsync<TResult>(int skip, int take, Expression<Func<Entity, TResult>> selector);

        Task<IList<TResult>> GetAsync<TResult>(int skip, int take, Expression<Func<Entity, bool>> predicate, Expression<Func<Entity, TResult>> selector);


        Task<IList<Entity>> GetAsync(int skip, int take);

        Task<IList<Entity>> GetAsync(Expression<Func<Entity, bool>> predicate);

        Task<IList<Entity>> GetAsync(int skip, int take, Expression<Func<Entity, bool>> predicate);

        Task<Entity> FindAsync(Expression<Func<Entity, bool>> predicate);

        Task<Entity> FindAsync(long primaryKey);

        Task<TResult> FindAsync<TResult>(long primaryKey, Expression<Func<Entity, TResult>> selector);

        Task<TResult> FindAsync<TResult>(Expression<Func<Entity, bool>> predicate, Expression<Func<Entity, TResult>> selector);

        Task<long> CountAsync();

        Task<Entity> AddAsync(Entity entity);

        Entity Delete(Entity entity);

        Entity Edit(Entity entity);

        void SaveAsync();
    }
}
