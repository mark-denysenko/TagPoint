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
        Task<IDataResult<PostModel>> GetPostAsync(long id);
        Task<IResult> DeletePostAsync(long id);
        Task<IDataResult<IEnumerable<MarkerModel>>> GetMarkerWithPostsNearAsync(Coordinate center, double radius, long userId);
        Task<IDataResult<IEnumerable<PostModel>>> GetUserPosts(long userId, PostsRequest postsRequest);
        Task<int> ToggleLikePostAync(long postId, long userId);

    }
}
