using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using WeatherAttack.Domain.Contracts;

namespace WeatherAttack.Infra.Repositories
{
    public abstract class Repository<C, Entity> :
        IRepository<Entity> where Entity : class where C : WeatherAttackContext
    {
        public Repository(WeatherAttackContext context)
        {
            Context = context;
        }

        protected WeatherAttackContext Context { get; set; }

        public virtual IQueryable<Entity> GetAll()
        {
            IQueryable<Entity> query = Context.Set<Entity>().AsNoTracking();
            return query;
        }

        public virtual IQueryable<Entity> FindBy(Expression<Func<Entity, bool>> predicate)
        {
            IQueryable<Entity> query = Context.Set<Entity>().Where(predicate).AsNoTracking();
            return query;
        }       

        public virtual IQueryable<Entity> FindBy(Expression<Func<Entity, bool>> predicate, Expression<Func<Entity, Entity>> selectField)
        {
            IQueryable<Entity> query = Context.Set<Entity>().Where(predicate).Select(selectField).AsNoTracking();
            return query;
        }

        public virtual IQueryable<Entity> Include(Expression<Func<Entity, object>> predicate)
        {
            return Context.Set<Entity>().Include(predicate);
        }

        public virtual IQueryable<Entity> Take(int count)
        {
            return Context.Set<Entity>().Take(count);
        }

        public virtual IQueryable<Entity> Skip(int count)
        {
            return Context.Set<Entity>().Skip(20);
        }

        public virtual IQueryable<Entity> PagedGet(int skip, int take)
        {
            return Context.Set<Entity>().Skip(skip).Take(take);
        }

        public virtual long Count()
        {
            return Context.Set<Entity>().LongCount(u => 1==1);
        }

        public virtual void Add(Entity entity)
        {
            Context.Set<Entity>().Add(entity);          
        }

        public virtual void Delete(Entity entity)
        {
            Context.Set<Entity>().Remove(entity);
        }

        public virtual void Edit(Entity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            Context.SaveChanges();
        }
    }
}
