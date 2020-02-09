using Domain.Vote;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Vote
{
    public class DislikeConfiguration : IEntityTypeConfiguration<DislikeEntity>
    {
        public void Configure(EntityTypeBuilder<DislikeEntity> builder)
        {
            builder.ToTable("Dislikes");

            builder.HasNoKey();

            //builder.HasAlternateKey(dislike
            //    => new
            //    {
            //        UserId = dislike.User.Id,
            //        PostId = dislike.Post.Id
            //    });
        }
    }
}
