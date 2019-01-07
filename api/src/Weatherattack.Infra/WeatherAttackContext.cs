using Microsoft.EntityFrameworkCore;
using WeatherAttack.Infra.Mapping;
using WeatherAttack.Domain.Entities;

namespace WeatherAttack.Infra
{
    public class WeatherAttackContext : DbContext
    {
        public WeatherAttackContext(DbContextOptions optionsBuilder) : base(optionsBuilder)
        {
            this.Database.Migrate();         
        }

        public DbSet<User> UsersContext { get; set; }

        public DbSet<Character> CharactersContext { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new CharacterMapping());
        }
    }

}
