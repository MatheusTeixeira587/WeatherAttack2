﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using WeatherAttack.Domain.Contracts;

namespace WeatherAttack.Infra.Repositories
{
    public abstract class Repository<Db, Entity> : IRepository<Entity> 
        where Entity : class 
        where Db: DbContext
    {
        protected DbContext Context { get; set; }

        public virtual IQueryable<Entity> Get()
            => Context.Set<Entity>().AsNoTracking();

        public virtual IQueryable<Entity> Get(int skip, int take)
            => Get().Skip(skip).Take(take);

        public virtual IQueryable<Entity> Find(Expression<Func<Entity, bool>> predicate)
            => Context.Set<Entity>().AsNoTracking().Where(predicate);

        public virtual Entity Find(long primaryKey) 
            => Context.Set<Entity>().Find(primaryKey);

        public virtual long Count()
            => Context.Set<Entity>().LongCount(u => 1==1);

        public virtual void Add(Entity entity)
            => Context.Set<Entity>().Add(entity);

        public virtual void Delete(Entity entity)
            => Context.Set<Entity>().Remove(entity);

        public virtual void Edit(Entity entity)
            => Context.Entry(entity).State = EntityState.Modified;

        public virtual void Save()
            => Context.SaveChanges();

        protected Repository(DbContext context)
        {
            Context = context;
        }
    }
}
