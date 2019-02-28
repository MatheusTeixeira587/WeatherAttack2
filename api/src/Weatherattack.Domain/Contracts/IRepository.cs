using System;
using System.Linq;
using System.Linq.Expressions;

namespace WeatherAttack.Domain.Contracts
{
    public interface IRepository<Entity> where Entity : class
    {
        IQueryable<Entity> GetAll();

        IQueryable<Entity> FindBy(Expression<Func<Entity, bool>> predicate);

        IQueryable<Entity> FindBy(Expression<Func<Entity, bool>> predicate, Expression<Func<Entity, Entity>> selectField);

        void Add(Entity entity);

        void Delete(Entity entity);

        void Edit(Entity entity);

        void Save();
    }
}
