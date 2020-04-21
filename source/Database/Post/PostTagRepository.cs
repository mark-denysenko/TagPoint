using Domain.Post;
using DotNetCore.EntityFrameworkCore;
using DotNetCoreArchitecture.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Post
{
    public class PostTagRepository : EntityFrameworkCoreRelationalRepository<PostTagEntity>, IPostTagRepository
    {
        public PostTagRepository(Context context) : base(context)
        {
        }
    }
}
