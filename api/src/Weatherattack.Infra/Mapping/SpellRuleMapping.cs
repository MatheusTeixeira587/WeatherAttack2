using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherAttack.Domain.Entities;
using WeatherAttack.Domain.Enums;

namespace WeatherAttack.Infra.Mapping
{
    class SpellRuleMapping : IEntityTypeConfiguration<SpellRule>
    {
        public void Configure(EntityTypeBuilder<SpellRule> builder)
        {
            builder.ToTable("SpellRules");

            builder.HasKey(u => u.Id)
                .IsClustered();

            builder.Property(m => m.Id)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(u => u.Value)
                .IsRequired();

            builder.Property(u => u.Operator)
                .IsRequired()
                .HasConversion(
                    v => (byte)v, 
                    v => (Operator)v
                );

            builder.Ignore(u => u.Notifications);

            builder.Property(u => u.WeatherCondition)
                .IsRequired()
                .HasConversion(
                    v => (byte)v,
                    v => (WeatherCondition)v
                );
        }
    }
}