using DotNetCore.Objects;
using Model.Models.Post;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Post
{
    public interface IPostApplicationService
    {
        Task<IDataResult<long>> CreatePostAsync(PostModel post);
        Task<IDataResult<PostModel>> GetPostAsync(int id);
        Task<IResult> DeletePostAsync(int id);
        Task<IResult> GetPostsNearAsync();
    }
}
