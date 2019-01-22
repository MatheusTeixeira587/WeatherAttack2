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

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(Rules.User.Email.MaxLength);

            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(Rules.User.Username.MaxLength);

            builder.Property(u => u.Password)
                .IsRequired();

            builder.HasOne(u => u.Character).WithOne().HasForeignKey<Character>(c => c.UserId);
        }
    }
}
