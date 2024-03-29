using Domain.Post;
using DotNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Post
{
    public interface IPostTagRepository : IRelationalRepository<PostTagEntity>
    {
    }
}
