using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Entities;

namespace WeatherAttack.Infra.Repositories
{
    public sealed class CharacterRepository : Repository<WeatherAttackContext, Character>, ICharacterRepository
    {
        public CharacterRepository(WeatherAttackContext context) : base(context) { }
    }
}
