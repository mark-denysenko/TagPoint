using Domain.Vote;
using DotNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Vote
{
    public interface ILikeRepository : IRelationalRepository<LikeEntity>//, IRelationalRepository<DislikeEntity>
    {
        void Remove(long postId, long userId);
    }
}
