using Domain.ValueObjects;
using DotNetCore.Objects;
using Model.Models.Map;
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
        Task<IDataResult<IEnumerable<MarkerModel>>> GetPostsNearAsync(Coordinate center, double radius);
    }
}
