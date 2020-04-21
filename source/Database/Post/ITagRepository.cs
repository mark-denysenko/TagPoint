using Domain.Post;
using DotNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Post
{
    public interface ITagRepository : IRelationalRepository<TagEntity>
    {
        void CreateTags(IEnumerable<string> tags, long userId);
        IEnumerable<TagEntity> GetTagsByNames(IEnumerable<string> tags);
        IEnumerable<TagEntity> GetTags(string keyword);
    }
}
