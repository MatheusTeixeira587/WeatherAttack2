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

        public override IQueryable<User> FindBy(Expression<Func<User, bool>> predicate)
        {
            return base.FindBy(predicate).Include(i => i.Character);
        }

        public override IQueryable<User> PagedGet(int skip, int take)
        {
            return base.PagedGet(skip, take).Include(u => u.Character);
        }
    }
}
