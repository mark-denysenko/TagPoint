using Domain.Post;
using DotNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Database.Post
{
    public interface ITagSelectionRepository : IRelationalRepository<TagSelectionEntity>
    {
        Task CreateTagSelectionForUser(string tag, long userId);
        Task CreateTagSelectionForUser(long tagId, long userId);
        Task<IEnumerable<string>> GetUserTagSelection(long id);
    }
}
