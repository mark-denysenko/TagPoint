using Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.User
{
    public sealed class UserAvatarConfiguration : IEntityTypeConfiguration<UserAvatarEntity>
    {
        public void Configure(EntityTypeBuilder<UserAvatarEntity> builder)
        {
            builder.ToTable("Avatars", "User");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.HasOne(x => x.User).WithOne(x => x.Avatar);
        }
    }
}
