using Domain.Vote;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Vote
{
    public class LikeConfiguration : IEntityTypeConfiguration<LikeEntity>
    {
        public void Configure(EntityTypeBuilder<LikeEntity> builder)
        {
            builder.ToTable("Likes");

            builder.HasKey(dislike => new { dislike.UserId, dislike.PostId }).HasName("COMBINE_PK_LIKE");
        }
    }
}
