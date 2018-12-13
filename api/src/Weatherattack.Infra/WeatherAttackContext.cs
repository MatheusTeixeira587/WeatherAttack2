using Microsoft.EntityFrameworkCore;
using Weatherattack.Infra.Interfaces;
using Weatherattack.Infra.Mapping;
using WeatherAttack.Domain.Entities;

namespace Weatherattack.Infra
{
    public class WeatherAttackContext : DbContext
    {
        public WeatherAttackContext() : base() { }

        public IDatabaseOptions DataBaseOptions { get; }

        public DbSet<User> UsersContext { get; set; }

        public DbSet<Character> CharactersContext { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DataBaseOptions.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new CharacterMapping());
        }
    }

}
