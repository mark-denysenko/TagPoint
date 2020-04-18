using Database.Point;
using Database.Post;
using Database.Vote;
using Domain.Point;
using Domain.Post;
using Domain.ValueObjects;
using DotNetCore.Objects;
using DotNetCoreArchitecture.Database;
using DotNetCoreArchitecture.Domain;
using Model.Models.Map;
using Model.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Post
{
    public class PostApplicationService : IPostApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPostRepository _postRepository;
        private readonly IPointRepository _pointRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILikeRepository _likesRepository;

        public PostApplicationService(
            IUnitOfWork unitOfWork,
            IPostRepository postRepository,
            IPointRepository pointRepository,
            IUserRepository userRepository,
            ILikeRepository likesRepository)
        {
            _unitOfWork = unitOfWork;
            _postRepository = postRepository;
            _pointRepository = pointRepository;
            _userRepository = userRepository;
            _likesRepository = likesRepository;
        }

        public async Task<IDataResult<long>> CreatePostAsync(PostModel post)
        {
            var user = _userRepository.FirstOrDefault(u => u.Id == post.UserId);

            PointEntity point = await _pointRepository.FirstOrDefaultWhereIncludeAsync(p => p.Id == post.Marker.Id, p => p.Posts);
            if (point is null)
            {
                point = new PointEntity
                {
                    Coordinate = new Coordinate
                    {
                        Latitude = post.Marker.Latitude,
                        Longitude = post.Marker.Longitude
                    }
                };
                await _pointRepository.AddAsync(point);
                point.User = user;
            }

            var newPost = new PostEntity
            {
                Message = post.Message,
                Location = post.Location
            };

            await _postRepository.AddAsync(newPost);
            newPost.Point = point;
            newPost.User = user;

            await _unitOfWork.SaveChangesAsync();

            return DataResult<long>.Success(newPost.Id);
        }

        public async Task<IResult> DeletePostAsync(long id)
        {
            var post = await _postRepository.FirstOrDefaultWhereIncludeAsync(p => p.Id == id, post => post.Point);
            await _postRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();

            var point = await _pointRepository.FirstOrDefaultWhereIncludeAsync(p => p.Id == post.Point.Id, p => p.Posts);
            if (!point.Posts.Any())
            {
                await _pointRepository.DeleteAsync(post.Point.Id);
            }

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        public async Task<IDataResult<PostModel>> GetPostAsync(long id)
        {
            var post = await _postRepository.SingleOrDefaultWhereIncludeAsync(p => p.Id == id, p => p.User);

            return DataResult<PostModel>.Success(CreatePostModel(post));
        }

        public async Task<IDataResult<IEnumerable<MarkerModel>>> GetMarkerWithPostsNearAsync(Coordinate center, double radius, long userId)
        {
            var markersInRadius = await _pointRepository.GetPointsInRadius(center, radius);

            var postsIds = markersInRadius.SelectMany(m => m.Posts.Select(p => p.Id)).ToList();
            var posts = await _postRepository.ListWhereIncludeAsync(p => postsIds.Contains(p.Id), p => p.Point, p => p.User, p => p.Likes);
            var usersIds = posts.Select(p => p.User.Id);
            var users = await _userRepository.ListWhereIncludeAsync(u => usersIds.Contains(u.Id), u => u.Avatar);
            foreach (var post in posts)
            {
                post.User = users.First(u => u.Id == post.User.Id);
            }

            return DataResult<IEnumerable<MarkerModel>>.Success(markersInRadius.Select(m =>
                new MarkerModel
                {
                    Id = m.Id,
                    Latitude = m.Coordinate.Latitude,
                    Longitude = m.Coordinate.Longitude,
                    Posts = posts.Where(p => p.Point.Id == m.Id)
                        .Select(p =>
                        {
                            var returnPost = CreatePostModel(p);
                            returnPost.Liked = p.Likes.Any(like => like.UserId == userId);
                            returnPost.TimesLiked = p.Likes.Count;
                            returnPost.Editable = p.User.Id == userId;

                            return returnPost;
                        })
                }));
        }

        public async Task<IDataResult<IEnumerable<PostModel>>> GetUserPosts(long userId, PostsRequest postsRequest)
        {
            var posts = await _postRepository.ListWhereIncludeAsync(post => post.User.Id == userId, p => p.User, p => p.User, p => p.Likes);

            var postsResult = posts.Select(CreatePostModel);

            if (postsRequest.OrderByDateAsc.HasValue)
            {
                postsResult = postsRequest.OrderByDateAsc.Value
                    ? postsResult.OrderBy(p => p.CreationDate)
                    : postsResult.OrderByDescending(p => p.CreationDate);
            }

            if (postsRequest.OrderByLikesAsc.HasValue)
            {
                postsResult = postsRequest.OrderByLikesAsc.Value
                    ? postsResult.OrderBy(p => p.Liked)
                    : postsResult.OrderByDescending(p => p.Liked);
            }

            if (!string.IsNullOrWhiteSpace(postsRequest.Keyword))
            {
                postsResult = postsResult.Where(p => p.Message.Contains(postsRequest.Keyword)
                    || p.Location.Contains(postsRequest.Keyword)
                    || p.TimesLiked.ToString().Contains(postsRequest.Keyword));
            }

            return DataResult<IEnumerable<PostModel>>.Success(postsResult);
        }

        public async Task<int> ToggleLikePostAync(long postId, long userId)
        {
            var user = await _userRepository.SingleOrDefaultWhereIncludeAsync(u => u.Id == userId, u => u.Likes);
            var post = await _postRepository.SingleOrDefaultWhereIncludeAsync(p => p.Id == postId, p => p.Likes);

            var like = post.Likes.FirstOrDefault(like => like.UserId == userId);
            if (like is null)
            {
                like = new Domain.Vote.LikeEntity
                {
                    PostId = postId,
                    UserId = userId,
                };
                await _likesRepository.AddAsync(like);
                post.Likes.Add(like);
                user.Likes.Add(like);
            }
            else
            {
                _likesRepository.Remove(postId, userId);
            }

            await _unitOfWork.SaveChangesAsync();
            post = await _postRepository.SingleOrDefaultWhereIncludeAsync(p => p.Id == postId, p => p.Likes);

            return post.Likes.Count;
        }

        private PostModel CreatePostModel(PostEntity post)
        {
            return new PostModel
            {
                Id = post.Id,
                Message = post.Message,
                Location = post.Location,
                CreationDate = post.PostDate.ToUniversalTime(),
                TimesLiked = post.Likes.Count,
                UserId = post.User.Id,
                Username = post.User.Username,
                UserAvatar = post.User.Avatar?.Avatar
            };
        }
    }
}
