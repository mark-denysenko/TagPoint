using Domain.Vote;
using DotNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Vote
{
    public interface IVoteRepository : IRelationalRepository<LikeEntity>,
        IRelationalRepository<DislikeEntity>
    {
    }
}
