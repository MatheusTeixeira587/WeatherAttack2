using Microsoft.EntityFrameworkCore;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Entities;

namespace WeatherAttack.Infra.Repositories
{
    public class SpellRepository : Repository<WeatherAttackContext, Spell>, ISpellRepository
    {
        public SpellRepository(DbContext context) : base(context) { }
    }
}
