using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WeatherAttack.Domain.Contracts
{
    public interface IRepository<Entity> where Entity : class
    {
        IQueryable<Entity> Get();

        IQueryable<Entity> Get(int skip, int take);

        Entity Find(long primaryKey);

        IQueryable<Entity> Find(Expression<Func<Entity, bool>> predicate);

        long Count();

        void Add(Entity entity);

        void Delete(Entity entity);

        void Edit(Entity entity);

        void Save();
    }
}
