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

        protected override IQueryable<User> RawGet()
            => base.RawGet().Include(u => u.Character);
    }
}
