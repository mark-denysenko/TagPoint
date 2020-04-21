using Domain.Post;
using DotNetCore.EntityFrameworkCore;
using DotNetCoreArchitecture.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database.Post
{
    public class TagRepository : EntityFrameworkCoreRelationalRepository<TagEntity>, ITagRepository
    {
        public TagRepository(Context context) : base(context)
        {
        }

        public void CreateTags(IEnumerable<string> tags, long userId)
        {
            var tagsToCreate = tags
                .Where(t => t != null && !string.IsNullOrWhiteSpace(t))
                .Select(t => new TagEntity
                {
                    Tag = t.Trim().ToLowerInvariant(),
                    CreatedById = userId
                })
                .ToList();
            var existedTags = ListInclude().Select(t => t.Tag);
            var needCreate = tagsToCreate.Where(t => !existedTags.Contains(t.Tag));

            AddRange(needCreate);
        }

        public IEnumerable<TagEntity> GetTags(string keyword)
        {
            var formattedKeyword = keyword.Trim().ToLowerInvariant();
            return ListWhereInclude(t => t.Tag.ToLowerInvariant().Contains(formattedKeyword));
        }

        public IEnumerable<TagEntity> GetTagsByNames(IEnumerable<string> tags)
        {
            var formattedTags = tags.Select(t => t.Trim().ToLowerInvariant()).ToList();
            return ListWhereInclude(t => formattedTags.Contains(t.Tag));
        }
    }
}
