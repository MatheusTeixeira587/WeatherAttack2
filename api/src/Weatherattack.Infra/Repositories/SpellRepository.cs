using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Entities;

namespace WeatherAttack.Infra.Repositories
{
    public class SpellRepository : Repository<WeatherAttackContext, Spell>, ISpellRepository
    {
        public SpellRepository(WeatherAttackContext context) : base(context) { }

        public override IQueryable<Spell> FindBy(Expression<Func<Spell, bool>> predicate)
        {
            return base.FindBy(predicate).Include(s => s.Rules);
        }
    }
}
