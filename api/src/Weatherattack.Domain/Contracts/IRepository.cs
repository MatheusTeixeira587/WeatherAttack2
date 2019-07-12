using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WeatherAttack.Domain.Contracts
{
    public interface IRepository<Entity> where Entity : class
    {
        IQueryable<Entity> GetAll();

        IQueryable<Entity> FindBy(Expression<Func<Entity, bool>> predicate);

        IQueryable<Entity> FindBy(Expression<Func<Entity, bool>> predicate, Expression<Func<Entity, Entity>> selectField);

        IQueryable<Entity> Include(Expression<Func<Entity, object>> predicate);

        IQueryable<Entity> Take(int count);

        IQueryable<Entity> Skip(int count);

        IQueryable<Entity> PagedGet(int skip, int take);

        long Count();

        void Add(Entity entity);

        void Delete(Entity entity);

        void Edit(Entity entity);

        void Save();
    }
}
