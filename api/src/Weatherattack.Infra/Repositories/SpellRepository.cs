using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Entities;

namespace WeatherAttack.Infra.Repositories
{
    public sealed class SpellRepository : Repository<WeatherAttackContext, Spell>, ISpellRepository
    {
        public SpellRepository(WeatherAttackContext context) : base(context) { }

        protected override IQueryable<Spell> RawGet()
            => base.RawGet().Include(r => r.Rules);
    }
}
