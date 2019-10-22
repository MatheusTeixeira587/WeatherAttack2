using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherAttack.Domain.Entities;
using WeatherAttack.Domain.EntityValidation.Rules;

namespace WeatherAttack.Infra.Mapping
{
    class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id)
                .IsClustered();

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(Rules.User.Email.MaxLength);

            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(Rules.User.Username.MaxLength);

            builder.Property(u => u.Password)
                .IsRequired();

            builder.Property(u => u.PermissionLevel)
                .IsRequired();

            builder.Ignore(u => u.Notifications);

            builder.HasAlternateKey(u => u.Email);

            builder.HasAlternateKey(u => u.Username);

            builder.HasOne(u => u.Character)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey<Character>(c => c.UserId);

            builder.HasIndex(u => new { u.Email, u.Username })
               .HasName("IX_USER")
               .IsUnique();
        }
    }
}
