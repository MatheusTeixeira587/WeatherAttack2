using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using weatherattack2.src.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using weatherattack2.src.Domain.EntityValidation.Rules.User;

namespace Weatherattack.Infra.Mapping
{
    class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(UserRules.NameRules.MaxLength);
            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(UserRules.EmailRules.MaxLength);
            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(UserRules.UsernameRules.MaxLength);
            builder.Property(u => u.Password)
                .IsRequired();
            builder.HasOne(u => u.Character).WithOne(u => u.user);
        }
    }
}
