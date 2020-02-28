using Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.User
{
    public sealed class UserContactConfiguration : IEntityTypeConfiguration<UserContactEntity>
    {
        public void Configure(EntityTypeBuilder<UserContactEntity> builder)
        {
            builder.ToTable("UserContacts", "User");

            builder.HasNoKey();

            //builder.HasMany(x => x.UsersLogs).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            //builder.HasOne(x => x.Avatar).WithOne(x => x.User);
        }
    }
}
