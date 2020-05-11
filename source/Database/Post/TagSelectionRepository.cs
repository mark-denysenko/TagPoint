using Domain.Post;
using DotNetCore.EntityFrameworkCore;
using DotNetCoreArchitecture.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Database.Post
{
    public class TagSelectionRepository : EntityFrameworkCoreRelationalRepository<TagSelectionEntity>, ITagSelectionRepository
    {
        private readonly ITagRepository tagRepository;
        private readonly Context context;

        public TagSelectionRepository(ITagRepository tagRepository, Context context) : base(context)
        {
            this.tagRepository = tagRepository;
            this.context = context;
        }

        public async Task CreateTagSelectionForUser(long tagId, long userId)
        {
            await AddAsync(new TagSelectionEntity
            {
                TagId = tagId,
                UserId = userId
            });
            await context.SaveChangesAsync();
        }

        public async Task CreateTagSelectionForUser(string tagName, long userId)
        {
            var tag = tagRepository.GetTagsByNames(new List<string> { tagName }).FirstOrDefault()?.Id;

            if (!tag.HasValue)
            {
                tagRepository.CreateTags(new List<string> { tagName }, userId);
                await context.SaveChangesAsync();

                tag = tagRepository.GetTagsByNames(new List<string> { tagName }).FirstOrDefault()?.Id;
            }

            await CreateTagSelectionForUser(tag.Value, userId);
        }

        public async Task<IEnumerable<string>> GetUserTagSelection(long id)
        {
            return await context.TagSelections
                .Where(t => t.UserId == id)
                .GroupBy(t => t.Tag.Tag)
                .OrderByDescending(t => t.Count())
                .Select(t => t.Key)
                .ToListAsync();
        }
    }
}
