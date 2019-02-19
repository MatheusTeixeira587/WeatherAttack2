using System.Linq;
using Microsoft.EntityFrameworkCore;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Entities;

namespace WeatherAttack.Infra.Repositories
{
    public class UserRepository : Repository<WeatherAttackContext, User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) { }
    }
}
