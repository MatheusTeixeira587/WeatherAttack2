using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WeatherAttack.Domain.Contracts;

namespace WeatherAttack.Infra.Repositories
{
    public abstract class Repository<C, Entity> :
        IRepository<Entity> where Entity : class where C : DbContext
    {
        public Repository(DbContext context)
        {
            Context = context;
        }

        protected DbContext Context { get; set; }

        public virtual IQueryable<Entity> GetAll()
        {
            IQueryable<Entity> query = Context.Set<Entity>().AsNoTracking();
            return query;
        }

        public IQueryable<Entity> FindBy(System.Linq.Expressions.Expression<Func<Entity, bool>> predicate)
        { 
            IQueryable<Entity> query = Context.Set<Entity>().Where(predicate);
            return query;
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
