using System.Linq;
using WeatherAttack.Domain.Entities;

namespace WeatherAttack.Domain.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
