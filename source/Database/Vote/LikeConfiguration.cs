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

            builder.HasNoKey();

            //builder.HasIndex(dislike
            //    => new
            //    {
            //        UserId = dislike.User.Id,
            //        PostId = dislike.Post.Id
            //    })
            //    .IsUnique();

            //builder.HasAlternateKey(dislike
            //    => new
            //    {
            //        UserId = dislike.User.Id,
            //        PostId = dislike.Post.Id
            //    });
        }
    }
}
