using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherAttack.Domain.Entities;
using WeatherAttack.Domain.EntityValidation.Rules;

namespace WeatherAttack.Infra.Mapping
{
    class CharacterMapping : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.ToTable("Characters");

            builder.HasKey(c => c.Id)
                .ForSqlServerIsClustered();

            builder.Ignore(c => c.Notifications);

            builder.Property(c => c.Battles)
                .HasDefaultValue(Rules.Character.Battles.InitialValue);

            builder.Property(c => c.Wins)
                .HasDefaultValue(Rules.Character.Wins.InitialValue);

            builder.Property(c => c.Losses)
                .HasDefaultValue(Rules.Character.Losses.InitialValue);

            builder.Property(c => c.Medals)
                .HasDefaultValue(Rules.Character.Medals.InitialValue);
        }
    }
}
