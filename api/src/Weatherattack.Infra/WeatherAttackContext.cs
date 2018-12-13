using Microsoft.EntityFrameworkCore;
using Weatherattack.Domain.Entities;
using Weatherattack.Infra.interfaces;
using Weatherattack.Infra.Mapping;
using weatherattack2.src.Domain.Entities;

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
