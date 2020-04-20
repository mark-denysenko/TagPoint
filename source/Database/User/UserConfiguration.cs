using DotNetCoreArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetCoreArchitecture.Database
{
    public sealed class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users", "User");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Roles).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Username).IsRequired().HasMaxLength(100);

            builder.Property(x => x.About).HasMaxLength(255).HasDefaultValue(string.Empty);
            builder.Property(x => x.PhoneNumber).HasMaxLength(20).HasDefaultValue(string.Empty);

            builder.Property(x => x.RegisterDate).IsRequired().HasDefaultValueSql("GETDATE()");

            builder.OwnsOne(x => x.Email, y =>
            {
                y.Property(x => x.Address).HasColumnName(nameof(UserEntity.Email)).IsRequired().HasMaxLength(300);
                y.HasIndex(x => x.Address).IsUnique();
            });

            builder.OwnsOne(x => x.SignIn, y =>
            {
                y.Property(x => x.Login).HasColumnName(nameof(UserEntity.SignIn.Login)).IsRequired().HasMaxLength(100);
                y.Property(x => x.Password).HasColumnName(nameof(UserEntity.SignIn.Password)).IsRequired().HasMaxLength(500);
                y.Property(x => x.Salt).HasColumnName(nameof(UserEntity.SignIn.Salt)).IsRequired().HasMaxLength(500);
                y.HasIndex(x => x.Login).IsUnique();
            });

            //builder.HasOne(x => x.Avatar).WithOne(x => x.User);
        }
    }
}
