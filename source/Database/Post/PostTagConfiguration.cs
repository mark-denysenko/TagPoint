using Domain.Post;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Post
{
    public class PostTagConfiguration : IEntityTypeConfiguration<PostTagEntity>
    {
        public void Configure(EntityTypeBuilder<PostTagEntity> builder)
        {
            builder.ToTable("PostTags");

            builder.HasKey(postTag => new { postTag.TagId, postTag.PostId });
        }
    }
}
