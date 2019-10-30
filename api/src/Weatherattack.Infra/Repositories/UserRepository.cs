using Microsoft.EntityFrameworkCore;
using System.Linq;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Entities;

namespace WeatherAttack.Infra.Repositories
{
    public sealed class UserRepository : Repository<WeatherAttackContext, User>, IUserRepository
    {
        public UserRepository(WeatherAttackContext context) : base(context) { }

        protected override IQueryable<User> RawGet()
            => base.RawGet().Include(u => u.Character);
    }
}
