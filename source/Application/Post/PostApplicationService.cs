using Database.Point;
using Database.Post;
using Database.Vote;
using Domain.Point;
using Domain.Post;
using Domain.ValueObjects;
using DotNetCore.Objects;
using DotNetCoreArchitecture.Database;
using DotNetCoreArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
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
        private readonly ITagRepository _tagRepository;
        private readonly IPostTagRepository _postTagRepository;

        public PostApplicationService(
            IUnitOfWork unitOfWork,
            IPostRepository postRepository,
            IPointRepository pointRepository,
            IUserRepository userRepository,
            ILikeRepository likesRepository,
            ITagRepository tagRepository,
            IPostTagRepository postTagRepository)
        {
            _unitOfWork = unitOfWork;
            _postRepository = postRepository;
            _pointRepository = pointRepository;
            _userRepository = userRepository;
            _likesRepository = likesRepository;
            _tagRepository = tagRepository;
            _postTagRepository = postTagRepository;
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
                Recommended = post.Recommended,
                PostDate = DateTime.UtcNow,
                Location = post.Location
            };

            await _postRepository.AddAsync(newPost);
            newPost.Point = point;
            newPost.User = user;

            _tagRepository.CreateTags(post.Tags, user.Id);

            await _unitOfWork.SaveChangesAsync();

            var postTags = _tagRepository.GetTagsByNames(post.Tags);
            await _postTagRepository.AddRangeAsync(postTags.Select(t => new PostTagEntity
            {
                PostId = newPost.Id,
                TagId = t.Id
            }));

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

            await _pointRepository.IncrementPointViews(markersInRadius.Select(p => p.Id));
            await _unitOfWork.SaveChangesAsync();

            var postsIds = markersInRadius.SelectMany(m => m.Posts.Select(p => p.Id)).ToList();
            var posts = await _postRepository.Posts
                .AsNoTracking()
                .Include(p => p.Likes)
                .Include(p => p.Point)
                .Include(p => p.Tags)
                .Include(p => p.User)
                .ThenInclude(u => u.Avatar)
                .Where(p => postsIds.Contains(p.Id))
                .ToListAsync();

            var existedTags = await _tagRepository.ListAsync();
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
                            returnPost.Tags = existedTags.Where(t => p.Tags.Any(pt => pt.TagId == t.Id)).Select(t => t.Tag);

                            return returnPost;
                        })
                }));
        }

        public async Task<IDataResult<IEnumerable<PostModel>>> GetUserPosts(long userId, PostsRequest postsRequest)
        {
            var posts = await _postRepository.ListWhereIncludeAsync(post => post.User.Id == userId, p => p.User, p => p.User, p => p.Likes, p => p.Point);

            var postsResult = posts.Select(p =>
            {
                var post = CreatePostModel(p);
                post.Views = p.Point.TotalViews;

                return post;
            });

            if (postsRequest.OrderByDateDesc.HasValue)
            {
                postsResult = postsRequest.OrderByDateDesc.Value
                    ? postsResult.OrderByDescending(p => p.CreationDate)
                    : postsResult.OrderBy(p => p.CreationDate);
            }

            if (postsRequest.OrderByLikesDesc.HasValue)
            {
                postsResult = postsRequest.OrderByLikesDesc.Value
                    ? postsResult.OrderByDescending(p => p.TimesLiked)
                    : postsResult.OrderBy(p => p.TimesLiked);
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
                Recommended = post.Recommended,
                CreationDate = post.PostDate.ToUniversalTime(),
                TimesLiked = post.Likes.Count,
                UserId = post.User.Id,
                Username = post.User.Username,
                UserAvatar = post.User.Avatar?.Avatar
            };
        }
    }
}
