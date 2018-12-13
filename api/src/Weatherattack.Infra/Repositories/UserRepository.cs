using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Entities;

namespace Weatherattack.Infra.Repositories
{
    public class UserRepository : GenericRepository<WeatherAttackContext, User>, IUserRepository
    {
    }
}
