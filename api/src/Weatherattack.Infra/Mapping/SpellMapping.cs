using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WeatherAttack.Domain.Entities;
using WeatherAttack.Domain.EntityValidation.Rules;
using WeatherAttack.Domain.Enums;

namespace WeatherAttack.Infra.Mapping
{
    class SpellMapping : IEntityTypeConfiguration<Spell>
    {
        public void Configure(EntityTypeBuilder<Spell> builder)
        {
            builder.ToTable("Spells");

            builder.HasKey(m => m.Id)
                .IsClustered();

            builder.Property(m => m.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder.Property(m => m.BaseDamage)
                .IsRequired();

            builder.Property(m => m.BaseManaCost)
                .IsRequired();

            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(Rules.Spell.Name.MaxLenght);

            builder.Property(m => m.Element)
                .IsRequired()
                .HasConversion(
                    v => (byte)v,
                    v => (Element)v
                );

            builder.Ignore(u => u.Notifications);

            builder.HasMany(m => m.Rules)
                .WithOne(m => m.Spell)
                .HasForeignKey(m => m.SpellId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}