using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Entities;

namespace WeatherAttack.Infra.Repositories
{
    public abstract class Repository<Db, Entity> : IRepository<Entity>
        where Entity : EntityBase
    where Db : DbContext
    {
        protected DbContext Context { get; set; }

        protected virtual IQueryable<Entity> RawGet() => Context.Set<Entity>().AsNoTracking();

        public virtual async Task<IList<Entity>> GetAsync() => await RawGet().ToListAsync();

        public virtual async Task<IList<TResult>> GetAsync<TResult>(Expression<Func<Entity, TResult>> selector) => await RawGet().Select(selector).ToListAsync();

        public virtual async Task<IList<TResult>> GetAsync<TResult>(Expression<Func<Entity, bool>> predicate, Expression<Func<Entity, TResult>> selector) => await RawGet().Where(predicate).Select(selector).ToListAsync();

        public virtual async Task<IList<TResult>> GetAsync<TResult>(int skip, int take, Expression<Func<Entity, TResult>> selector) => await RawGet().Skip(skip).Take(take).Select(selector).ToListAsync();

        public virtual async Task<IList<TResult>> GetAsync<TResult>(int skip, int take, Expression<Func<Entity, bool>> predicate, Expression<Func<Entity, TResult>> selector) => await RawGet().Where(predicate).Skip(skip).Take(take).Select(selector).ToListAsync();

        public virtual async Task<IList<Entity>> GetAsync(int skip, int take) => await RawGet().Skip(skip).Take(take).ToListAsync();

        public virtual async Task<IList<Entity>> GetAsync(int skip, int take, Expression<Func<Entity, bool>> predicate) => await RawGet().Where(predicate).Skip(skip).Take(take).ToListAsync();

        public virtual async Task<IList<Entity>> GetAsync(Expression<Func<Entity, bool>> predicate) => await RawGet().Where(predicate).ToListAsync();

        public virtual async Task<Entity> FindAsync(Expression<Func<Entity, bool>> predicate) => await RawGet().SingleOrDefaultAsync(predicate);

        public virtual async Task<Entity> FindAsync(long primaryKey) => await RawGet().SingleOrDefaultAsync(e => e.Id == primaryKey);

        public virtual async Task<TResult> FindAsync<TResult>(long primaryKey, Expression<Func<Entity, TResult>> selector) => await RawGet().Where(e => e.Id == primaryKey).Select(selector).SingleOrDefaultAsync();

        public virtual async Task<TResult> FindAsync<TResult>(Expression<Func<Entity, bool>> predicate, Expression<Func<Entity, TResult>> selector) => await RawGet().Where(predicate).Select(selector).SingleOrDefaultAsync();

        public virtual async Task<long> CountAsync() => await Context.Set<Entity>().LongCountAsync(u => 1 == 1);

        public virtual async Task<Entity> AddAsync(Entity entity)
        {
            await Context.Set<Entity>().AddAsync(entity);
            return entity;
        }

        public virtual Entity Delete(Entity entity)
        {
            Context.Set<Entity>().Remove(entity);
            return entity;
        }

        public virtual Entity Edit(Entity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public virtual async void SaveAsync() => await Context.SaveChangesAsync();

        protected Repository(DbContext context)
        {
            Context = context;
        }
    }
}