using Domain.Post;
using DotNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database.Post
{
    public interface IPostRepository : IRelationalRepository<PostEntity>
    {
        public IQueryable<PostEntity> Posts { get; }
    }
}
