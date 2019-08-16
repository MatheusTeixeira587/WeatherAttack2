using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Entities;

namespace WeatherAttack.Infra.Repositories
{
    public class UserRepository : Repository<WeatherAttackContext, User>, IUserRepository
    {
        public UserRepository(WeatherAttackContext context) : base(context) { }

        public override IQueryable<User> Find(Expression<Func<User, bool>> predicate)
            => base.Find(predicate).Include(i => i.Character);

        public override IQueryable<User> Get()
            => base.Get().Include(u => u.Character);
    }
}
