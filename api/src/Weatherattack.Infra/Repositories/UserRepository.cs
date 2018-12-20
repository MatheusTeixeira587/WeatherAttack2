using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Entities;

namespace WeatherAttack.Infra.Repositories
{
    public class UserRepository : GenericRepository<WeatherAttackContext, User>, IUserRepository
    {
    }
}
