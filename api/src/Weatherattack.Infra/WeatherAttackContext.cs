using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Weatherattack.Domain.Entities;
using Weatherattack.Infra.Mapping;
using weatherattack2.src.Domain.Entities;

namespace Weatherattack.Infra
{
    public class WeatherAttackContext : DbContext
    {
        public WeatherAttackContext(DbContextOptions options) : base(options) { }

        public DbSet<User> UsersContext { get; set; }

        public DbSet<Character> CharactersContext { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new CharacterMapping());
        }
    }

}
