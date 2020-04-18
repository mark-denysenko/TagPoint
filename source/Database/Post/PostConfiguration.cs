using Domain.Post;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Post
{
    public class PostConfiguration : IEntityTypeConfiguration<PostEntity>
    {
        public void Configure(EntityTypeBuilder<PostEntity> builder)
        {
            builder.ToTable("Posts");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Message).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Location).IsRequired().HasDefaultValue(string.Empty);
            builder.Property(x => x.PostDate).IsRequired().HasDefaultValueSql("GETDATE()");
        }
    }
}
