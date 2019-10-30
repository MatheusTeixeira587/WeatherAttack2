using Microsoft.EntityFrameworkCore;
using WeatherAttack.Infra.Mapping;
using WeatherAttack.Domain.Entities;

namespace WeatherAttack.Infra
{
    public sealed class WeatherAttackContext : DbContext
    {
        public WeatherAttackContext(DbContextOptions optionsBuilder) : base(optionsBuilder)
        {
            Database.Migrate();
        }

        public DbSet<User> UsersContext { get; }

        public DbSet<Character> CharactersContext { get; }

        public DbSet<Spell> SpellsContext { get; }

        public DbSet<SpellRule> SpellsRulesContext { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityColumns();
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new CharacterMapping());
            modelBuilder.ApplyConfiguration(new SpellMapping());
            modelBuilder.ApplyConfiguration(new SpellRuleMapping());
        }
    }
}
