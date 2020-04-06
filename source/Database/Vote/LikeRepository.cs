using Domain.Vote;
using DotNetCore.EntityFrameworkCore;
using DotNetCoreArchitecture.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Vote
{
    public class LikeRepository : EntityFrameworkCoreRelationalRepository<LikeEntity>, ILikeRepository
    {
        private readonly Context context;
        public LikeRepository(Context context) : base(context)
        {
            this.context = context;
        }

        public void Remove(long postId, long userId)
        {
            var like = context.Likes.Find(userId, postId);
            context.Likes.Remove(like);
        }
    }
}
