using Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Contact
{
    public sealed class ContactTypeConfiguration : IEntityTypeConfiguration<ContactTypeEntity>
    {
        public void Configure(EntityTypeBuilder<ContactTypeEntity> builder)
        {
            builder.ToTable("ContactType");

            builder.HasKey(x => x.Id);

            //builder.HasMany(x => x.UsersLogs).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            //builder.HasOne(x => x.Avatar).WithOne(x => x.User);
        }
    }
}
